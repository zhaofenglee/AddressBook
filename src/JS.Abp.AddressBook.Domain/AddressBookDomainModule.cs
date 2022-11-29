using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace JS.Abp.AddressBook;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AddressBookDomainSharedModule)
)]
public class AddressBookDomainModule : AbpModule
{

}
