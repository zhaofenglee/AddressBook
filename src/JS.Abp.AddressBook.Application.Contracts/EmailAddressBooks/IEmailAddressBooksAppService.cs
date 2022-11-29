using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using JS.Abp.AddressBook.Shared;

namespace JS.Abp.AddressBook.EmailAddressBooks
{
    public interface IEmailAddressBooksAppService : IApplicationService
    {
        Task<PagedResultDto<EmailAddressBookDto>> GetListAsync(GetEmailAddressBooksInput input);

        Task<EmailAddressBookDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<EmailAddressBookDto> CreateAsync(EmailAddressBookCreateDto input);

        Task<EmailAddressBookDto> UpdateAsync(Guid id, EmailAddressBookUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(EmailAddressBookExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}