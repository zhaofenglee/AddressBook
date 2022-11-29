using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace JS.Abp.AddressBook.EntityFrameworkCore;

public class AddressBookHttpApiHostMigrationsDbContext : AbpDbContext<AddressBookHttpApiHostMigrationsDbContext>
{
    public AddressBookHttpApiHostMigrationsDbContext(DbContextOptions<AddressBookHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureAddressBook();
    }
}
