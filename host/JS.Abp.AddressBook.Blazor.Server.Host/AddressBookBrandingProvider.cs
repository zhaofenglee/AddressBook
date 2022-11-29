using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace JS.Abp.AddressBook.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class AddressBookBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AddressBook";
}
