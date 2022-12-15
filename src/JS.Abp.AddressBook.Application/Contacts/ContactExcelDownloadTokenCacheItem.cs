using System;

namespace JS.Abp.AddressBook.Contacts;

[Serializable]
public class ContactExcelDownloadTokenCacheItem
{
    public string Token { get; set; }
}