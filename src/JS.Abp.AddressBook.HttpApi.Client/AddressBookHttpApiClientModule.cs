using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace JS.Abp.AddressBook;

[DependsOn(
    typeof(AddressBookApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AddressBookHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AddressBookApplicationContractsModule).Assembly,
            AddressBookRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AddressBookHttpApiClientModule>();
        });

    }
}
