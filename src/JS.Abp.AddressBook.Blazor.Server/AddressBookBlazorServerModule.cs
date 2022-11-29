using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.AddressBook.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(AddressBookBlazorModule)
    )]
public class AddressBookBlazorServerModule : AbpModule
{

}
