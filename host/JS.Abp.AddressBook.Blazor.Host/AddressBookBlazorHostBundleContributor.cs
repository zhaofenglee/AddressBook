using Volo.Abp.Bundling;

namespace JS.Abp.AddressBook.Blazor.Host;

public class AddressBookBlazorHostBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true);
    }
}
