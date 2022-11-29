using Volo.Abp.Modularity;

namespace JS.Abp.AddressBook;

[DependsOn(
    typeof(AddressBookApplicationModule),
    typeof(AddressBookDomainTestModule)
    )]
public class AddressBookApplicationTestModule : AbpModule
{

}
