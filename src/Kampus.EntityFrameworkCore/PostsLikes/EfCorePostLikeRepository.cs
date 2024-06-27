using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kampus.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Kampus.PostsLikes
{
    public class EfCorePostLikeRepository : EfCoreRepository<KampusDbContext, PostLike, Guid>, IPostLikeRepository
    {
        public EfCorePostLikeRepository(IDbContextProvider<KampusDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<PostLike>> GetByPostIdAsync(Guid postId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(pl => pl.PostId == postId).ToListAsync();

        }

        public async Task<List<PostLike>> GetByUserIdAsync(Guid userId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(pl => pl.UserId == userId).ToListAsync();
        }

        public async Task<int> GetLikeCountByPostIdAsync(Guid postId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(pl => pl.PostId == postId).CountAsync();
        }

        public async Task<int> GetLikeCountByUserIdAsync(Guid userId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(pl => pl.UserId == userId).CountAsync();
        }
    }
}
