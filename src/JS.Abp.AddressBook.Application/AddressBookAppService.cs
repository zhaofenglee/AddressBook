using JS.Abp.AddressBook.Localization;
using Volo.Abp.Application.Services;

namespace JS.Abp.AddressBook;

public abstract class AddressBookAppService : ApplicationService
{
    protected AddressBookAppService()
    {
        LocalizationResource = typeof(AddressBookResource);
        ObjectMapperContext = typeof(AddressBookApplicationModule);
    }
}
