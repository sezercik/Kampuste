using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Kampus.Posts;

public class PostAppService : ApplicationService, IPostAppService
{
    private readonly IPostRepository _postRepository;
    private readonly PostManager _postManager;
    private readonly ICurrentUser _currentUser;
    
    public PostAppService(
        IPostRepository postRepository, 
        PostManager postManager,
        ICurrentUser currentUser
        )
    {
        _postRepository = postRepository;
        _postManager = postManager;
        _currentUser = currentUser;
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
        //TODO: check for users role to make sure they are allowed to create a post
        if (_currentUser.IsAuthenticated)
        {
            Guid userId = _currentUser.Id ?? Guid.Empty;
            var newPost = await _postManager.CreateAsync(userId, input.Content, input.BlobNames);
            await _postRepository.InsertAsync(newPost);
            return ObjectMapper.Map<Post, PostDto>(newPost);
        }
        return null;
    }

    [Authorize]
    public async Task<bool> DeleteAsync(Guid id)
    {
        var currentUserRoles = _currentUser.Roles;
        var isAdmin = Array.Exists(currentUserRoles, role => role == "admin");
        var post = await _postRepository.GetByIdAsync(id);

        //TODO: if you add more roles like moderator you should add here too
        if (_currentUser.IsAuthenticated && (_currentUser.Id == post.UserId || isAdmin))
        {
            post.IsDeleted = true;
            await _postRepository.DeleteAsync(id);
            return true;
        }

        return false;
    }
}
  