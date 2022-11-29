using Volo.Abp.Reflection;

namespace JS.Abp.AddressBook.Permissions;

public class AddressBookPermissions
{
    public const string GroupName = "AddressBook";

    public static class EmailAddressBooks
    {
        public const string Default = GroupName + ".EmailAddressBooks";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AddressBookPermissions));
    }
}
