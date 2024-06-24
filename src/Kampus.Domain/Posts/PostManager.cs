using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Kampus;

public class PostManager : DomainService
{
    private readonly IPostRepository _postRepository;

    public PostManager(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    // public async Task<Post> GetByIdAsync(Guid postId)
    // {
    //     var post = await _postRepository.GetByIdAsync(postId);
    //     return post;
    // }

    // public async Task<List<Post>> GetListOfPosts()
    // {
    //     var posts = await _postRepository.GetListOfPosts();
    //     return posts;
    // }
    //
    // public async Task<List<Post>> GetListByUserIdAsync(
    //     Guid userId,
    //     int skipCount,
    //     int maxResultCount,
    //     string sorting,
    //     string filter = null
    //     )
    // {
    //     var posts = await _postRepository.GetListByUserIdAsync(
    //         userId,
    //         skipCount,
    //         maxResultCount,
    //         sorting,
    //         filter
    //     );
    //     return posts;
    // }

    public async Task<Post> CreateAsync(Guid userId, string content, string[]? blobNames)
    {
        return new Post(
            GuidGenerator.Create(),
            userId:userId,
            content:content,
            blobNames:blobNames
        );
    }
}