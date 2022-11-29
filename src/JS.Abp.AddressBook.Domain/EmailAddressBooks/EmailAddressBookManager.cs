using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace JS.Abp.AddressBook.EmailAddressBooks
{
    public class EmailAddressBookManager : DomainService
    {
        private readonly IEmailAddressBookRepository _emailAddressBookRepository;

        public EmailAddressBookManager(IEmailAddressBookRepository emailAddressBookRepository)
        {
            _emailAddressBookRepository = emailAddressBookRepository;
        }

        public async Task<EmailAddressBook> CreateAsync(
        string userId, string userName, string emailAddress, string description)
        {
            var emailAddressBook = new EmailAddressBook(
             GuidGenerator.Create(),
             userId, userName, emailAddress, description
             );

            return await _emailAddressBookRepository.InsertAsync(emailAddressBook);
        }

        public async Task<EmailAddressBook> UpdateAsync(
            Guid id,
            string userId, string userName, string emailAddress, string description, [CanBeNull] string concurrencyStamp = null
        )
        {
            var queryable = await _emailAddressBookRepository.GetQueryableAsync();
            var query = queryable.Where(x => x.Id == id);

            var emailAddressBook = await AsyncExecuter.FirstOrDefaultAsync(query);

            emailAddressBook.UserId = userId;
            emailAddressBook.UserName = userName;
            emailAddressBook.EmailAddress = emailAddress;
            emailAddressBook.Description = description;

            emailAddressBook.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _emailAddressBookRepository.UpdateAsync(emailAddressBook);
        }

    }
}