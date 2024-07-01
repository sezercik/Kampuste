using Kampus.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace Kampus.UserFollows
{
    public class EfCoreUserFollowRepository : EfCoreRepository<KampusDbContext, UserFollow, Guid>, IUserFollowRepository
    {
        public EfCoreUserFollowRepository(IDbContextProvider<KampusDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<UserFollow>> GetPendingUserFollowers(Guid userId, int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                uf => uf.Followee.NormalizedUserName.Contains(filter))
                .Where(uf => uf.FolloweeId == userId && uf.Status == UserFolloweeType.Pending && !uf.IsDeleted)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<List<UserFollow>> GetUserFollowees(Guid userId, int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), uf => uf.Follower.NormalizedUserName.Contains(filter))
                .Where(uf => uf.FollowerId == userId && !uf.IsDeleted)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<List<UserFollow>> GetUserFollowers(Guid userId, int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), uf => uf.Followee.NormalizedUserName.Contains(filter))
                .Where(uf => uf.FolloweeId == userId && !uf.IsDeleted)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
