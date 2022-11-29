using Volo.Abp;
using Volo.Abp.MongoDB;

namespace JS.Abp.AddressBook.MongoDB;

public static class AddressBookMongoDbContextExtensions
{
    public static void ConfigureAddressBook(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
