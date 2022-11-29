using JS.Abp.AddressBook.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace JS.Abp.AddressBook;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(AddressBookEntityFrameworkCoreTestModule)
    )]
public class AddressBookDomainTestModule : AbpModule
{

}
