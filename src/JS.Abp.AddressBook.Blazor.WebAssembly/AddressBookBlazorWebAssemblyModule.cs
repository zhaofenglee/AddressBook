using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace JS.Abp.AddressBook.Blazor.WebAssembly;

[DependsOn(
    typeof(AddressBookBlazorModule),
    typeof(AddressBookHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class AddressBookBlazorWebAssemblyModule : AbpModule
{

}
