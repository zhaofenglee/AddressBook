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
using JS.Abp.AddressBook.EmailAddressBooks;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using JS.Abp.AddressBook.Shared;

namespace JS.Abp.AddressBook.EmailAddressBooks
{

    [Authorize(AddressBookPermissions.EmailAddressBooks.Default)]
    public class EmailAddressBooksAppService : ApplicationService, IEmailAddressBooksAppService
    {
        private readonly IDistributedCache<EmailAddressBookExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IEmailAddressBookRepository _emailAddressBookRepository;
        private readonly EmailAddressBookManager _emailAddressBookManager;

        public EmailAddressBooksAppService(IEmailAddressBookRepository emailAddressBookRepository, EmailAddressBookManager emailAddressBookManager, IDistributedCache<EmailAddressBookExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _emailAddressBookRepository = emailAddressBookRepository;
            _emailAddressBookManager = emailAddressBookManager;
        }

        public virtual async Task<PagedResultDto<EmailAddressBookDto>> GetListAsync(GetEmailAddressBooksInput input)
        {
            var totalCount = await _emailAddressBookRepository.GetCountAsync(input.FilterText, input.UserId, input.UserName, input.EmailAddress, input.Description);
            var items = await _emailAddressBookRepository.GetListAsync(input.FilterText, input.UserId, input.UserName, input.EmailAddress, input.Description, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<EmailAddressBookDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<EmailAddressBook>, List<EmailAddressBookDto>>(items)
            };
        }

        public virtual async Task<EmailAddressBookDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<EmailAddressBook, EmailAddressBookDto>(await _emailAddressBookRepository.GetAsync(id));
        }

        [Authorize(AddressBookPermissions.EmailAddressBooks.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _emailAddressBookRepository.DeleteAsync(id);
        }

        [Authorize(AddressBookPermissions.EmailAddressBooks.Create)]
        public virtual async Task<EmailAddressBookDto> CreateAsync(EmailAddressBookCreateDto input)
        {

            var emailAddressBook = await _emailAddressBookManager.CreateAsync(
            input.UserId, input.UserName, input.EmailAddress, input.Description
            );

            return ObjectMapper.Map<EmailAddressBook, EmailAddressBookDto>(emailAddressBook);
        }

        [Authorize(AddressBookPermissions.EmailAddressBooks.Edit)]
        public virtual async Task<EmailAddressBookDto> UpdateAsync(Guid id, EmailAddressBookUpdateDto input)
        {

            var emailAddressBook = await _emailAddressBookManager.UpdateAsync(
            id,
            input.UserId, input.UserName, input.EmailAddress, input.Description, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<EmailAddressBook, EmailAddressBookDto>(emailAddressBook);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(EmailAddressBookExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _emailAddressBookRepository.GetListAsync(input.FilterText, input.UserId, input.UserName, input.EmailAddress, input.Description);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<EmailAddressBook>, List<EmailAddressBookExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "EmailAddressBooks.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new EmailAddressBookExcelDownloadTokenCacheItem { Token = token },
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