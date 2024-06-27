using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Kampus.Posts;

public class PostAppService : ApplicationService, IPostAppService
{
    private readonly IPostRepository _postRepository;
    private readonly PostManager _postManager;
    
    public PostAppService(IPostRepository postRepository, PostManager postManager)
    {
        _postRepository = postRepository;
        _postManager = postManager;
    }


    public async Task<PagedResultDto<PostDto>> GetPostListByUserId(GetPostListDtoByUserId input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Post.Content);
        }
        var posts = await _postRepository.GetListByUserIdAsync(
                input.userId,
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

        var totalCount = input.Filter == null
            ? await _postRepository.CountAsync()
            : await _postRepository.CountAsync(p => p.Content.Contains(input.Filter));
        return new PagedResultDto<PostDto>(
            totalCount,
            ObjectMapper.Map<List<Post>, List<PostDto>>(posts)
        );
    }

    public async Task<PostDto> GetPostById(Guid postId)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        return ObjectMapper.Map<Post,PostDto>(post);
    }

    public async Task<PagedResultDto<PostDto>> GetListPosts(GetPostListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Post.Content);
        }
        var posts = await _postRepository.GetListOfPosts(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _postRepository.CountAsync()
            : await _postRepository.CountAsync(p => p.Content.Contains(input.Filter));
        return new PagedResultDto<PostDto>(
            totalCount,
            ObjectMapper.Map<List<Post>,List<PostDto>>(posts)
        );
    }

    [Authorize]
    public async Task<PostDto> CreatePost(CreatePostDto input)
    {
        var newPost = await _postManager.CreateAsync(input.UserId,input.Content,input.BlobNames);
        await _postRepository.InsertAsync(newPost);
        return ObjectMapper.Map<Post, PostDto>(newPost);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await _postRepository.DeleteAsync(id);
    }
}
  