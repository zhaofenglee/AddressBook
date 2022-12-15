using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using JS.Abp.AddressBook.Permissions;
using JS.Abp.AddressBook.Contacts;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using JS.Abp.AddressBook.Shared;

namespace JS.Abp.AddressBook.Contacts
{
    [RemoteService(IsEnabled = false)]
    [Authorize(AddressBookPermissions.Contacts.Default)]
    public class ContactsAppService : ApplicationService, IContactsAppService
    {
        private readonly IDistributedCache<ContactExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IContactRepository _contactRepository;
        private readonly ContactManager _contactManager;

        public ContactsAppService(IContactRepository contactRepository, ContactManager contactManager, IDistributedCache<ContactExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _contactRepository = contactRepository;
            _contactManager = contactManager;
        }

        public virtual async Task<PagedResultDto<ContactDto>> GetListAsync(GetContactsInput input)
        {
            var totalCount = await _contactRepository.GetCountAsync(input.FilterText, input.UserId, input.UserName, input.PhoneNumber, input.Telephone, input.Address, input.AgeMin, input.AgeMax, input.BirthdayMin, input.BirthdayMax, input.Description);
            var items = await _contactRepository.GetListAsync(input.FilterText, input.UserId, input.UserName, input.PhoneNumber, input.Telephone, input.Address, input.AgeMin, input.AgeMax, input.BirthdayMin, input.BirthdayMax, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ContactDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Contact>, List<ContactDto>>(items)
            };
        }

        public virtual async Task<ContactDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Contact, ContactDto>(await _contactRepository.GetAsync(id));
        }

        [Authorize(AddressBookPermissions.Contacts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        [Authorize(AddressBookPermissions.Contacts.Create)]
        public virtual async Task<ContactDto> CreateAsync(ContactCreateDto input)
        {

            var contact = await _contactManager.CreateAsync(
            input.UserId, input.UserName, input.PhoneNumber, input.Telephone, input.Address, input.Age, input.Description, input.Birthday
            );

            return ObjectMapper.Map<Contact, ContactDto>(contact);
        }

        [Authorize(AddressBookPermissions.Contacts.Edit)]
        public virtual async Task<ContactDto> UpdateAsync(Guid id, ContactUpdateDto input)
        {

            var contact = await _contactManager.UpdateAsync(
            id,
            input.UserId, input.UserName, input.PhoneNumber, input.Telephone, input.Address, input.Age, input.Description, input.Birthday, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Contact, ContactDto>(contact);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ContactExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _contactRepository.GetListAsync(input.FilterText, input.UserId, input.UserName, input.PhoneNumber, input.Telephone, input.Address, input.AgeMin, input.AgeMax, input.BirthdayMin, input.BirthdayMax, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Contact>, List<ContactExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Contacts.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ContactExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}