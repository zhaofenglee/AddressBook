using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using JS.Abp.AddressBook.EmailAddressBooks;

namespace JS.Abp.AddressBook.EntityFrameworkCore
{
    public class EfCoreEmailAddressBookRepository : EfCoreRepository<IAddressBookDbContext, EmailAddressBook, Guid>, IEmailAddressBookRepository
    {
        public EfCoreEmailAddressBookRepository(IDbContextProvider<IAddressBookDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<EmailAddressBook>> GetListAsync(
            string filterText = null,
            string userId = null,
            string userName = null,
            string emailAddress = null,
            string description = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetQueryableAsync(), filterText, userId, userName, emailAddress, description);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? EmailAddressBookConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string userId = null,
            string userName = null,
            string emailAddress = null,
            string description = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter(await GetDbSetAsync(), filterText, userId, userName, emailAddress, description);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<EmailAddressBook> ApplyFilter(
            IQueryable<EmailAddressBook> query,
            string filterText,
            string userId = null,
            string userName = null,
            string emailAddress = null,
            string description = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UserId.Contains(filterText) || e.UserName.Contains(filterText) || e.EmailAddress.Contains(filterText) || e.Description.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(userId), e => e.UserId.Contains(userId))
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.UserName.Contains(userName))
                    .WhereIf(!string.IsNullOrWhiteSpace(emailAddress), e => e.EmailAddress.Contains(emailAddress))
                    .WhereIf(!string.IsNullOrWhiteSpace(description), e => e.Description.Contains(description));
        }
    }
}