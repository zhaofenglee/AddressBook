using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.AddressBook.EntityFrameworkCore;

[ConnectionStringName(AddressBookDbProperties.ConnectionStringName)]
public class AddressBookDbContext : AbpDbContext<AddressBookDbContext>, IAddressBookDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAddressBook();
    }
}
