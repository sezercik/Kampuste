using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kampus.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Kampus.UserFriends
{
    public class EfCoreUserFriendRepository : EfCoreRepository<KampusDbContext, UserFriend, Guid>, IUserFriendRepository
    {
        public EfCoreUserFriendRepository(IDbContextProvider<KampusDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<UserFriend>> GetUserCloseFriends(Guid userId, int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.WhereIf
                (
                    !filter.IsNullOrWhiteSpace(),
                    uf => uf.FriendUser.NormalizedUserName.Contains(filter) && uf.UserFriendType == UserFriendType.CLOSEFRIEND
                )
                .Where(uf => uf.UserId == userId && uf.UserFriendType == UserFriendType.CLOSEFRIEND)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<List<UserFriend>> GetUserFriends(Guid userId, int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.WhereIf
                (
                    !filter.IsNullOrWhiteSpace(),
                    uf => uf.FriendUser.NormalizedUserName.Contains(filter)
                )
                .Where(p => p.UserId == userId)
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
