using JS.Abp.AddressBook.Contacts;
using JS.Abp.AddressBook.EmailAddressBooks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.AddressBook.EntityFrameworkCore;

[ConnectionStringName(AddressBookDbProperties.ConnectionStringName)]
public interface IAddressBookDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<Contact> Contacts { get; set; }
    DbSet<EmailAddressBook> EmailAddressBooks { get; set; }
}
