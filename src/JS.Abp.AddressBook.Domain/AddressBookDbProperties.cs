using Volo.Abp.Data;

namespace JS.Abp.AddressBook;

public static class AddressBookDbProperties
{
    public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

    public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

    public const string ConnectionStringName = "AddressBook";
}
