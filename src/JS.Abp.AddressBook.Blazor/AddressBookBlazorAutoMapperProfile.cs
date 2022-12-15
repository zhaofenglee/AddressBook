using AutoMapper;
using JS.Abp.AddressBook.Contacts;
using JS.Abp.AddressBook.EmailAddressBooks;

namespace JS.Abp.AddressBook.Blazor;

public class AddressBookBlazorAutoMapperProfile : Profile
{
    public AddressBookBlazorAutoMapperProfile()
    {
        CreateMap<EmailAddressBookDto, EmailAddressBookUpdateDto>();
        CreateMap<ContactDto, ContactUpdateDto>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
