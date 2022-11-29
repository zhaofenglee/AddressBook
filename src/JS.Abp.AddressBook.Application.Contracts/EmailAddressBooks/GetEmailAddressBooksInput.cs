using Volo.Abp.Application.Dtos;
using System;

namespace JS.Abp.AddressBook.EmailAddressBooks
{
    public class GetEmailAddressBooksInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }

        public GetEmailAddressBooksInput()
        {

        }
    }
}