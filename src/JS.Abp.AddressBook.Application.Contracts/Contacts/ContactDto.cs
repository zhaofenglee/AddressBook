using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace JS.Abp.AddressBook.Contacts
{
    public class ContactDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string Description { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}