using JS.Abp.AddressBook.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JS.Abp.AddressBook.Pages;

public abstract class AddressBookPageModel : AbpPageModel
{
    protected AddressBookPageModel()
    {
        LocalizationResourceType = typeof(AddressBookResource);
    }
}
