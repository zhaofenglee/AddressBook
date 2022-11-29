using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace JS.Abp.AddressBook.EmailAddressBooks
{
    public class EmailAddressBookDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}