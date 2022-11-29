using AutoMapper;
using JS.Abp.AddressBook.EmailAddressBooks;

namespace JS.Abp.AddressBook;

public class AddressBookApplicationAutoMapperProfile : Profile
{
    public AddressBookApplicationAutoMapperProfile()
    {
        CreateMap<EmailAddressBook, EmailAddressBookDto>();
        CreateMap<EmailAddressBook, EmailAddressBookExcelDto>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
