using JS.Abp.AddressBook.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JS.Abp.AddressBook.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AddressBookPageModel : AbpPageModel
{
    protected AddressBookPageModel()
    {
        LocalizationResourceType = typeof(AddressBookResource);
        ObjectMapperContext = typeof(AddressBookWebModule);
    }
}
