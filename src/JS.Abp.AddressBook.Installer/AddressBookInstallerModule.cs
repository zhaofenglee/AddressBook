using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace JS.Abp.AddressBook;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class AddressBookInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AddressBookInstallerModule>();
        });
    }
}
