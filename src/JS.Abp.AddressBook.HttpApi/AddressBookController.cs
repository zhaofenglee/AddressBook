using JS.Abp.AddressBook.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace JS.Abp.AddressBook;

public abstract class AddressBookController : AbpControllerBase
{
    protected AddressBookController()
    {
        LocalizationResource = typeof(AddressBookResource);
    }
}
