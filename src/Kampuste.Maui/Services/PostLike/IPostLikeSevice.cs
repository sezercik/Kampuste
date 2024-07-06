using Kampus.PostsLikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kampuste.Maui.Services.PostLike
{
    public interface  IPostLikeSevice
    {
        Task<List<PostLikeDto>> PostPostLikeAsync(Guid postId);
        Task<List<PostLikeDto>> DeletePostLikeAsync(Guid postId);
        Task<List<PostLikeDto>> GetLikeCountByPostIdAsync(Guid postId);
        Task<List<PostLikeDto>> GetLikeCountByUserIdAsync(Guid UserId);
        Task<List<PostLikeDto>> GetLikeListByPostIdAsync(Guid postId);
        Task<List<PostLikeDto>> GetLikeListByUserIdAsync(Guid UserId);
    }
}
