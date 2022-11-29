using Localization.Resources.AbpUi;
using JS.Abp.AddressBook.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace JS.Abp.AddressBook;

[DependsOn(
    typeof(AddressBookApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AddressBookHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AddressBookHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AddressBookResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
