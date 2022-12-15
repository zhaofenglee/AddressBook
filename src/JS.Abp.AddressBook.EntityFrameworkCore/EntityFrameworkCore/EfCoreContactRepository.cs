using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using JS.Abp.AddressBook.Contacts;

namespace JS.Abp.AddressBook.EntityFrameworkCore
{
    public class EfCoreContactRepository : EfCoreRepository<AddressBookDbContext, Contact, Guid>, IContactRepository
    {
        public EfCoreContactRepository(IDbContextProvider<AddressBookDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Contact>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetQueryableAsync(), filterText, userId, userName, phoneNumber, telephone, address, ageMin, ageMax, birthdayMin, birthdayMax, description);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ContactConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetDbSetAsync(), filterText, userId, userName, phoneNumber, telephone, address, ageMin, ageMax, birthdayMin, birthdayMax, description);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Contact> ApplyFilter(
            IQueryable<Contact> query,
            string filterText,
            string userId = null,
            string userName = null,
            string phoneNumber = null,
            string telephone = null,
            string address = null,
            int? ageMin = null,
            int? ageMax = null,
            DateTime? birthdayMin = null,
            DateTime? birthdayMax = null,
            string description = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UserId.Contains(filterText) || e.UserName.Contains(filterText) || e.PhoneNumber.Contains(filterText) || e.Telephone.Contains(filterText) || e.Address.Contains(filterText) || e.Description.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(userId), e => e.UserId.Contains(userId))
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.UserName.Contains(userName))
                    .WhereIf(!string.IsNullOrWhiteSpace(phoneNumber), e => e.PhoneNumber.Contains(phoneNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(telephone), e => e.Telephone.Contains(telephone))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address))
                    .WhereIf(ageMin.HasValue, e => e.Age >= ageMin.Value)
                    .WhereIf(ageMax.HasValue, e => e.Age <= ageMax.Value)
                    .WhereIf(birthdayMin.HasValue, e => e.Birthday >= birthdayMin.Value)
                    .WhereIf(birthdayMax.HasValue, e => e.Birthday <= birthdayMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.Contains(description));
        }
    }
}