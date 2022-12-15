using Volo.Abp.Application.Dtos;
using System;

namespace JS.Abp.AddressBook.Contacts
{
    public class ContactExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string FilterText { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public DateTime? BirthdayMin { get; set; }
        public DateTime? BirthdayMax { get; set; }
        public string Description { get; set; }

        public ContactExcelDownloadDto()
        {

        }
    }
}