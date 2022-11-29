using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace JS.Abp.AddressBook.MongoDB;

[ConnectionStringName(AddressBookDbProperties.ConnectionStringName)]
public interface IAddressBookMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
