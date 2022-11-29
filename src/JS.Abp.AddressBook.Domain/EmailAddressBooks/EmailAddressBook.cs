using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace JS.Abp.AddressBook.EmailAddressBooks
{
    public class EmailAddressBook : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string UserId { get; set; }

        [CanBeNull]
        public virtual string UserName { get; set; }

        [CanBeNull]
        public virtual string EmailAddress { get; set; }

        [CanBeNull]
        public virtual string Description { get; set; }

        public EmailAddressBook()
        {

        }

        public EmailAddressBook(Guid id, string userId, string userName, string emailAddress, string description)
        {

            Id = id;
            Check.NotNull(userId, nameof(userId));
            Check.Length(userId, nameof(userId), EmailAddressBookConsts.UserIdMaxLength, EmailAddressBookConsts.UserIdMinLength);
            Check.Length(userName, nameof(userName), EmailAddressBookConsts.UserNameMaxLength, 0);
            Check.Length(emailAddress, nameof(emailAddress), EmailAddressBookConsts.EmailAddressMaxLength, 0);
            Check.Length(description, nameof(description), EmailAddressBookConsts.DescriptionMaxLength, 0);
            UserId = userId;
            UserName = userName;
            EmailAddress = emailAddress;
            Description = description;
        }

    }
}