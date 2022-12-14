namespace JS.Abp.AddressBook;

public static class AddressBookDbProperties
{
    public static string DbTablePrefix { get; set; } = "App";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "AddressBook";
}
