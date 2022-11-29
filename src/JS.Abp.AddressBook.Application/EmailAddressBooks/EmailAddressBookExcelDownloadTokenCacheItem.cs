using System;

namespace JS.Abp.AddressBook.EmailAddressBooks;

[Serializable]
public class EmailAddressBookExcelDownloadTokenCacheItem
{
    public string Token { get; set; }
}