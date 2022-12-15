using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JS.Abp.AddressBook.Contacts
{
    public class ContactCreateDto
    {
        [Required]
        [StringLength(ContactConsts.UserIdMaxLength, MinimumLength = ContactConsts.UserIdMinLength)]
        public string UserId { get; set; }
        [StringLength(ContactConsts.UserNameMaxLength)]
        public string UserName { get; set; }
        [StringLength(ContactConsts.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }
        [StringLength(ContactConsts.TelephoneMaxLength)]
        public string Telephone { get; set; }
        [StringLength(ContactConsts.AddressMaxLength)]
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string Description { get; set; }
    }
}