using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JS.Abp.AddressBook.EntityFrameworkCore;

public class AddressBookHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AddressBookHttpApiHostMigrationsDbContext>
{
    public AddressBookHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AddressBookHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("AddressBook"));

        return new AddressBookHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
