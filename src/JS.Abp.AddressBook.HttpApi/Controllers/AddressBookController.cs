using JS.Abp.AddressBook.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace JS.Abp.AddressBook.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AddressBookController : AbpControllerBase
{
    protected AddressBookController()
    {
        LocalizationResource = typeof(AddressBookResource);
    }
}
