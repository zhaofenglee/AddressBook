using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using JS.Abp.AddressBook.EmailAddressBooks;
using Volo.Abp.Content;
using JS.Abp.AddressBook.Shared;

namespace JS.Abp.AddressBook.Controllers.EmailAddressBooks
{
    [RemoteService]
    [Area("app")]
    [ControllerName("EmailAddressBook")]
    [Route("api/app/email-address-books")]

    public class EmailAddressBookController : AbpController, IEmailAddressBooksAppService
    {
        private readonly IEmailAddressBooksAppService _emailAddressBooksAppService;

        public EmailAddressBookController(IEmailAddressBooksAppService emailAddressBooksAppService)
        {
            _emailAddressBooksAppService = emailAddressBooksAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<EmailAddressBookDto>> GetListAsync(GetEmailAddressBooksInput input)
        {
            return _emailAddressBooksAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<EmailAddressBookDto> GetAsync(Guid id)
        {
            return _emailAddressBooksAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<EmailAddressBookDto> CreateAsync(EmailAddressBookCreateDto input)
        {
            return _emailAddressBooksAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<EmailAddressBookDto> UpdateAsync(Guid id, EmailAddressBookUpdateDto input)
        {
            return _emailAddressBooksAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _emailAddressBooksAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(EmailAddressBookExcelDownloadDto input)
        {
            return _emailAddressBooksAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _emailAddressBooksAppService.GetDownloadTokenAsync();
        }
    }
}