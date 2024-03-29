﻿using JS.Abp.AddressBook.Contacts;
using JS.Abp.AddressBook.EmailAddressBooks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace JS.Abp.AddressBook.EntityFrameworkCore;

public static class AddressBookDbContextModelCreatingExtensions
{
    public static void ConfigureAddressBook(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(AddressBookDbProperties.DbTablePrefix + "Questions", AddressBookDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.Entity<EmailAddressBook>(b =>
        {
            b.ToTable(AddressBookDbProperties.DbTablePrefix + "EmailAddressBooks", AddressBookDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.UserId).HasColumnName(nameof(EmailAddressBook.UserId)).IsRequired().HasMaxLength(EmailAddressBookConsts.UserIdMaxLength);
            b.Property(x => x.UserName).HasColumnName(nameof(EmailAddressBook.UserName)).HasMaxLength(EmailAddressBookConsts.UserNameMaxLength);
            b.Property(x => x.EmailAddress).HasColumnName(nameof(EmailAddressBook.EmailAddress)).HasMaxLength(EmailAddressBookConsts.EmailAddressMaxLength);
            b.Property(x => x.Description).HasColumnName(nameof(EmailAddressBook.Description)).HasMaxLength(EmailAddressBookConsts.DescriptionMaxLength);
        });
        builder.Entity<Contact>(b =>
        {
            b.ToTable(AddressBookDbProperties.DbTablePrefix + "Contacts", AddressBookDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.UserId).HasColumnName(nameof(Contact.UserId)).IsRequired().HasMaxLength(ContactConsts.UserIdMaxLength);
            b.Property(x => x.UserName).HasColumnName(nameof(Contact.UserName)).HasMaxLength(ContactConsts.UserNameMaxLength);
            b.Property(x => x.PhoneNumber).HasColumnName(nameof(Contact.PhoneNumber)).HasMaxLength(ContactConsts.PhoneNumberMaxLength);
            b.Property(x => x.Telephone).HasColumnName(nameof(Contact.Telephone)).HasMaxLength(ContactConsts.TelephoneMaxLength);
            b.Property(x => x.Address).HasColumnName(nameof(Contact.Address)).HasMaxLength(ContactConsts.AddressMaxLength);
            b.Property(x => x.Age).HasColumnName(nameof(Contact.Age));
            b.Property(x => x.Birthday).HasColumnName(nameof(Contact.Birthday));
            b.Property(x => x.Description).HasColumnName(nameof(Contact.Description));
        });
    }
}
