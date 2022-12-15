using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace JS.Abp.AddressBook.Contacts
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {
        Task<List<Contact>> GetListAsync(
            string filterText = null,
            string userId = null,
            string userName = null,
            string phoneNumber = null,
            string telephone = null,
            string address = null,
            int? ageMin = null,
            int? ageMax = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
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
            string phoneNumber = null,
            string telephone = null,
            string address = null,
            int? ageMin = null,
            int? ageMax = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
            string description = null,
            CancellationToken cancellationToken = default);
    }
}