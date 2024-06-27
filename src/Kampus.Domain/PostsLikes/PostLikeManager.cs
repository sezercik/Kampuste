using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Services;

namespace Kampus.PostsLikes;

public class PostLikeManager : DomainService
{
    private readonly IPostLikeRepository _postLikeRepository;
    public PostLikeManager(IPostLikeRepository postLikeRepository)
    {
        _postLikeRepository = postLikeRepository;
    }

    public async Task<PostLike> CreateAsync(Guid userId, Guid postId)
    {
        return new PostLike(
          postId,
          userId
        );
    }
}