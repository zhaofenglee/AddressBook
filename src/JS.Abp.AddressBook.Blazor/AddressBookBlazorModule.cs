using Microsoft.Extensions.DependencyInjection;
using JS.Abp.AddressBook.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.AddressBook.Blazor;

[DependsOn(
    typeof(AddressBookApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class AddressBookBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AddressBookBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<AddressBookBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new AddressBookMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(AddressBookBlazorModule).Assembly);
        });
    }
}
