using AutoMapper;
using JS.Abp.AddressBook.Contacts;
using JS.Abp.AddressBook.EmailAddressBooks;

namespace JS.Abp.AddressBook;

public class AddressBookApplicationAutoMapperProfile : Profile
{
    public AddressBookApplicationAutoMapperProfile()
    {
        CreateMap<EmailAddressBook, EmailAddressBookDto>();
        CreateMap<EmailAddressBook, EmailAddressBookExcelDto>();

        CreateMap<Contact, ContactDto>();
        CreateMap<Contact, ContactExcelDto>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
