using JS.Abp.AddressBook.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JS.Abp.AddressBook.Permissions;

public class AddressBookPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AddressBookPermissions.GroupName, L("Permission:AddressBook"));

        var contactPermission = myGroup.AddPermission(AddressBookPermissions.Contacts.Default, L("Permission:Contacts"));
        contactPermission.AddChild(AddressBookPermissions.Contacts.Create, L("Permission:Create"));
        contactPermission.AddChild(AddressBookPermissions.Contacts.Edit, L("Permission:Edit"));
        contactPermission.AddChild(AddressBookPermissions.Contacts.Delete, L("Permission:Delete"));

        var emailAddressBookPermission = myGroup.AddPermission(AddressBookPermissions.EmailAddressBooks.Default, L("Permission:EmailAddressBooks"));
        emailAddressBookPermission.AddChild(AddressBookPermissions.EmailAddressBooks.Create, L("Permission:Create"));
        emailAddressBookPermission.AddChild(AddressBookPermissions.EmailAddressBooks.Edit, L("Permission:Edit"));
        emailAddressBookPermission.AddChild(AddressBookPermissions.EmailAddressBooks.Delete, L("Permission:Delete"));
        
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AddressBookResource>(name);
    }
}
