using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace JS.Abp.AddressBook.Contacts
{
    public class ContactManager : DomainService
    {
        private readonly IContactRepository _contactRepository;

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> CreateAsync(
        string userId, string userName, string phoneNumber, string telephone, string address, int age, string description, DateTime? birthday = null)
        {
            var contact = new Contact(
             GuidGenerator.Create(),
             userId, userName, phoneNumber, telephone, address, age, description, birthday
             );

            return await _contactRepository.InsertAsync(contact);
        }

        public async Task<Contact> UpdateAsync(
            Guid id,
            string userId, string userName, string phoneNumber, string telephone, string address, int age, string description, DateTime? birthday = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            var queryable = await _contactRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var contact = await AsyncExecuter.FirstOrDefaultAsync(query);

            contact.UserId = userId;
            contact.UserName = userName;
            contact.PhoneNumber = phoneNumber;
            contact.Telephone = telephone;
            contact.Address = address;
            contact.Age = age;
            contact.Description = description;
            contact.Birthday = birthday;

            contact.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _contactRepository.UpdateAsync(contact);
        }

    }
}