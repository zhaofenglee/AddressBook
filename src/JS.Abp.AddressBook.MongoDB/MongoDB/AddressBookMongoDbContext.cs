using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace JS.Abp.AddressBook.MongoDB;

[ConnectionStringName(AddressBookDbProperties.ConnectionStringName)]
public class AddressBookMongoDbContext : AbpMongoDbContext, IAddressBookMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureAddressBook();
    }
}
