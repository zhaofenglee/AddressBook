using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace JS.Abp.AddressBook;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AddressBookHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class AddressBookConsoleApiClientModule : AbpModule
{

}
