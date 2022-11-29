using JS.Abp.AddressBook.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JS.Abp.AddressBook.Permissions;

public class AddressBookPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AddressBookPermissions.GroupName, L("Permission:AddressBook"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AddressBookResource>(name);
    }
}
