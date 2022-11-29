using JS.Abp.AddressBook.Localization;
using JS.Abp.AddressBook.Permissions;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.AddressBook.Blazor.Menus;

public class AddressBookMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<AddressBookResource>();
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(AddressBookMenus.Prefix, displayName: "AddressBook", "/AddressBook", icon: "fa fa-globe"));

        context.Menu.AddItem(
            new ApplicationMenuItem(
                AddressBookMenus.EmailAddressBooks,
                l["Menu:EmailAddressBooks"],
                url: "/email-address-books",
                icon: "fa fa-file-alt",
                requiredPermissionName: AddressBookPermissions.EmailAddressBooks.Default)
        );

        return Task.CompletedTask;
    }
}
