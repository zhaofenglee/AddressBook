using System;

namespace JS.Abp.AddressBook.Contacts
{
    public class ContactExcelDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string Description { get; set; }
    }
}