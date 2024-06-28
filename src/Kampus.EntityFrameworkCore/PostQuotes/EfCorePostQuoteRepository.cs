using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kampus.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace Kampus.PostQuotes
{
    public class EfCorePostQuoteRepository : EfCoreRepository<KampusDbContext, PostQuote, Guid>, IPostQuoteRepository
    {
        public EfCorePostQuoteRepository(IDbContextProvider<KampusDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public async Task<List<PostQuote>> GetAllQuotesOfPost(Guid quotedPostId, int skipCount, int maxResultCount, string sorting, string filter = null)
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

        public async Task<PostQuote> GetByIdAsync(Guid quoteId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(p => p.Id == quoteId);
        }

        public async Task<PostQuote> GetQuoteByUserAndPost(Guid userId, Guid quotedPostId)
        {
           var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(p => p.CreatorId == userId && p.QuotedPostId == quotedPostId);
        }
    }
}
