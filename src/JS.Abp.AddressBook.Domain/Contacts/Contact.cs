using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace JS.Abp.AddressBook.Contacts
{
    public class Contact : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string UserId { get; set; }

        [CanBeNull]
        public virtual string UserName { get; set; }

        [CanBeNull]
        public virtual string PhoneNumber { get; set; }

        [CanBeNull]
        public virtual string Telephone { get; set; }

        [CanBeNull]
        public virtual string Address { get; set; }

        public virtual int Age { get; set; }

        public virtual DateTime? Birthday { get; set; }

        [CanBeNull]
        public virtual string Description { get; set; }

        public Contact()
        {

        }

        public Contact(Guid id, string userId, string userName, string phoneNumber, string telephone, string address, int age, string description, DateTime? birthday = null)
        {

            Id = id;
            Check.NotNull(userId, nameof(userId));
            Check.Length(userId, nameof(userId), ContactConsts.UserIdMaxLength, ContactConsts.UserIdMinLength);
            Check.Length(userName, nameof(userName), ContactConsts.UserNameMaxLength, 0);
            Check.Length(phoneNumber, nameof(phoneNumber), ContactConsts.PhoneNumberMaxLength, 0);
            Check.Length(telephone, nameof(telephone), ContactConsts.TelephoneMaxLength, 0);
            Check.Length(address, nameof(address), ContactConsts.AddressMaxLength, 0);
            UserId = userId;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Telephone = telephone;
            Address = address;
            Age = age;
            Description = description;
            Birthday = birthday;
        }

    }
}