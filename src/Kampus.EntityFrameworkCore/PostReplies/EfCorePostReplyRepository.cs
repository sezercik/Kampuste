using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kampus.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Kampus.PostReplies
{
    public class EfCorePostReplyRepository : EfCoreRepository<KampusDbContext, PostReply, Guid>, IPostReplyRepository
    {
        public EfCorePostReplyRepository(IDbContextProvider<KampusDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<PostReply>> GetAllReplyOfPost(Guid repliedPostId, int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.WhereIf
                (
                    !filter.IsNullOrWhiteSpace(),
                    p => p.Content.Contains(filter)
                )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();

        }

        public async Task<PostReply> GetByIdAsync(Guid replyId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(p => p.Id == replyId);
        }
    }
}