using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kampus.Posts;

public interface IPostAppService : IApplicationService
{
    Task<PagedResultDto<PostDto>> GetPostListByUserId(GetPostListDtoByUserId input);

    Task<PostDto> GetPostById(Guid postId);
    Task<PagedResultDto<PostDto>> GetListPosts(GetPostListDto input);
    Task<PostDto> CreatePost(CreatePostDto input);
}