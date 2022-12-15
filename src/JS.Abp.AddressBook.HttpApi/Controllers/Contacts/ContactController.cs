using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using JS.Abp.AddressBook.Contacts;
using Volo.Abp.Content;
using JS.Abp.AddressBook.Shared;

namespace JS.Abp.AddressBook.Controllers.Contacts
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Contact")]
    [Route("api/app/contacts")]

    public class ContactController : AbpController, IContactsAppService
    {
        private readonly IContactsAppService _contactsAppService;

        public ContactController(IContactsAppService contactsAppService)
        {
            _contactsAppService = contactsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ContactDto>> GetListAsync(GetContactsInput input)
        {
            return _contactsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ContactDto> GetAsync(Guid id)
        {
            return _contactsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ContactDto> CreateAsync(ContactCreateDto input)
        {
            return _contactsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ContactDto> UpdateAsync(Guid id, ContactUpdateDto input)
        {
            return _contactsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _contactsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ContactExcelDownloadDto input)
        {
            return _contactsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _contactsAppService.GetDownloadTokenAsync();
        }
    }
}