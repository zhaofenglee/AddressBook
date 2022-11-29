using Volo.Abp.Reflection;

namespace JS.Abp.AddressBook.Permissions;

public class AddressBookPermissions
{
    public const string GroupName = "AddressBook";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AddressBookPermissions));
    }
}
