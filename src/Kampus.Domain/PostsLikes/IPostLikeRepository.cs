using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kampus.PostsLikes;

public interface IPostLikeRepository : IRepository<PostLike, Guid>
{
    Task<List<PostLike>> GetByPostIdAsync(Guid postId);
    Task<List<PostLike>> GetByUserIdAsync(Guid userId);
    Task<int> GetLikeCountByPostIdAsync(Guid postId);
    Task<int> GetLikeCountByUserIdAsync(Guid userId);
}