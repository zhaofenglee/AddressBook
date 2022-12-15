namespace JS.Abp.AddressBook.Contacts
{
    public static class ContactConsts
    {
        private const string DefaultSorting = "{0}UserId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Contact." : string.Empty);
        }

        public const int UserIdMinLength = 1;
        public const int UserIdMaxLength = 36;
        public const int UserNameMaxLength = 50;
        public const int PhoneNumberMaxLength = 20;
        public const int TelephoneMaxLength = 20;
        public const int AddressMaxLength = 200;
    }
}