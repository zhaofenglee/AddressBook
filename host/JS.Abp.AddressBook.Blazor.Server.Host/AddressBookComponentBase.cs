using JS.Abp.AddressBook.Localization;
using Volo.Abp.AspNetCore.Components;

namespace JS.Abp.AddressBook.Blazor.Server.Host;

public abstract class AddressBookComponentBase : AbpComponentBase
{
    protected AddressBookComponentBase()
    {
        LocalizationResource = typeof(AddressBookResource);
    }
}
