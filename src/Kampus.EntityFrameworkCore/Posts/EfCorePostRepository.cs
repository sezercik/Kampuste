using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kampus.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Kampus.Migrations.Posts;

public class EfCorePostRepository : EfCoreRepository<KampusDbContext, Post, Guid>, IPostRepository
{
    public EfCorePostRepository( IDbContextProvider<KampusDbContext> dbContextProvider):base(dbContextProvider)
    {
    }


    public async Task<Post> GetByIdAsync(Guid postId)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(p => p.Id == postId);
    }

    public async Task<List<Post>> GetListOfPosts(int skipCount, int maxResultCount, string sorting, string filter = null)
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


    public async Task<List<Post>> GetListByUserIdAsync(Guid userId, int skipCount, int maxResultCount, string sorting, string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        var query = dbSet.Where(p => p.UserId == userId);
        return await query.WhereIf
            (
                !filter.IsNullOrWhiteSpace(),
                p => p.Content.Contains(filter)
            )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}