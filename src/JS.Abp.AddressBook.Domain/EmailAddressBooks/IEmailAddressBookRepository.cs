using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace JS.Abp.AddressBook.EmailAddressBooks
{
    public interface IEmailAddressBookRepository : IRepository<EmailAddressBook, Guid>
    {
        Task<List<EmailAddressBook>> GetListAsync(
            string filterText = null,
            string userId = null,
            string userName = null,
            string emailAddress = null,
            string description = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string userId = null,
            string userName = null,
            string emailAddress = null,
            string description = null,
            CancellationToken cancellationToken = default);
    }
}