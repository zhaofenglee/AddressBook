using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.AddressBook.EntityFrameworkCore;

[ConnectionStringName(AddressBookDbProperties.ConnectionStringName)]
public interface IAddressBookDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
