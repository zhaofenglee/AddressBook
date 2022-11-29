using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JS.Abp.AddressBook.EmailAddressBooks
{
    public class EmailAddressBookCreateDto
    {
        [Required]
        [StringLength(EmailAddressBookConsts.UserIdMaxLength, MinimumLength = EmailAddressBookConsts.UserIdMinLength)]
        public string UserId { get; set; }
        [StringLength(EmailAddressBookConsts.UserNameMaxLength)]
        public string UserName { get; set; }
        [EmailAddress]
        [StringLength(EmailAddressBookConsts.EmailAddressMaxLength)]
        public string EmailAddress { get; set; }
        [StringLength(EmailAddressBookConsts.DescriptionMaxLength)]
        public string Description { get; set; }
    }
}