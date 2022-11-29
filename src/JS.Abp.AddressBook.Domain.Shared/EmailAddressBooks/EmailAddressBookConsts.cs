namespace JS.Abp.AddressBook.EmailAddressBooks
{
    public static class EmailAddressBookConsts
    {
        private const string DefaultSorting = "{0}UserId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "EmailAddressBook." : string.Empty);
        }

        public const int UserIdMinLength = 1;
        public const int UserIdMaxLength = 36;
        public const int UserNameMaxLength = 50;
        public const int EmailAddressMaxLength = 50;
        public const int DescriptionMaxLength = 50;
    }
}