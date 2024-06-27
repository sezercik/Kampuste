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


    public async Task<Post> CreateAsync(Guid userId, string content, string[]? blobNames)
    {
        return new Post(
            userId:userId,
            content:content,
            blobNames:blobNames
        );
    }
}