using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace JS.Abp.AddressBook;

[DependsOn(
    typeof(AddressBookDomainModule),
    typeof(AddressBookApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class AddressBookApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AddressBookApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AddressBookApplicationModule>(validate: true);
        });
    }
}
