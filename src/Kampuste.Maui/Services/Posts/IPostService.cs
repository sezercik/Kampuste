using Kampus.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kampuste.Maui.Services.Posts
{
    public interface IPostService
    {
        Task<List<PostDto>> GetPostsAsync();
        Task<PostDto> GetPostByIdAsync(Guid postId);
        Task<List<PostDto>> GetPostListByUserIDAsync(Guid userId, string filter, string sorting, int skipCount, int MaxResultCount);
        Task<PostDto> PostPostAsync(PostDto post);
        Task<PostDto> DeletePostAsync(Guid postId);
    }
}
