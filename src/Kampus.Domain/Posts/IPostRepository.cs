using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kampus;

public interface IPostRepository : IRepository<Post, Guid>
{
    Task<Post> GetByIdAsync(Guid postId);
    Task<List<Post>> GetListOfPosts(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
        );
    Task<List<Post>> GetListByUserIdAsync(
        Guid userId,
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}