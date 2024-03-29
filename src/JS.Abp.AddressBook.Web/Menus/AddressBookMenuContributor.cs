﻿using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace JS.Abp.AddressBook.Web.Menus;

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
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(AddressBookMenus.Prefix, displayName: "AddressBook", "~/AddressBook", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
