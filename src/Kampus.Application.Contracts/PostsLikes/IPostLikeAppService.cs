using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Kampus.PostsLikes
{
    public interface IPostLikeAppService : IApplicationService
    {
        Task<List<PostLikeDto>> GetPostLikeListByUserId(GetPostLikeListDtoByUserId input);
        Task<List<PostLikeDto>> GetPostLikeListByPostId(GetPostLikeListDtoByPostId input);
        Task<int> GetPostLikeCountByUserId(GetPostLikeListDtoByUserId input);
        Task<int> GetPostLikeCountByPostId(GetPostLikeListDtoByPostId input);

        Task<bool> CreatePostLike(CreatePostLikeDto input);
    }
}
