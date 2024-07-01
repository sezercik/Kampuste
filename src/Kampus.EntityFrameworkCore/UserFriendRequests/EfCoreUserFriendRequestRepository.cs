using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kampus.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Kampus.UserFriendRequests
{
    public class EfCoreUserFriendRequestRepository : EfCoreRepository<KampusDbContext, UserFriendRequest, Guid>, IUserFriendRequestRepository
    {
        public EfCoreUserFriendRequestRepository(IDbContextProvider<KampusDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<UserFriendRequest>> GetReceivedFriendRequests(Guid userId, int skipCount, int maxResultCount, string sorting, string filter = null)
        {     
            var dbSet = await GetDbSetAsync();
            return await dbSet.WhereIf
                (
                    !filter.IsNullOrWhiteSpace(),
                    ufr => ufr.Sender.NormalizedUserName.Contains(filter)
                )
                .Where(ufr => ufr.ReceiverId == userId)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<List<UserFriendRequest>> GetSentFriendRequests(Guid userId, int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.WhereIf
                (
                    !filter.IsNullOrWhiteSpace(),
                    ufr => ufr.Receiver.NormalizedUserName.Contains(filter)
                )
                .Where(ufr => ufr.SenderId == userId)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
