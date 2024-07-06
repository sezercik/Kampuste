using Kampus.PostsLikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Kampuste.Maui.Services.PostLike
{
    internal class PostLikeService : IPostLikeSevice
    {
        private readonly HttpClient _httpClient;

        public PostLikeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PostLikeDto>> DeletePostLikeAsync(Guid postId)
        {
            string query = $"api/app/post-like/post-like?PostId={postId}";
            var response = await _httpClient.DeleteAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<List<PostLikeDto>> GetLikeCountByPostIdAsync(Guid postId)
        {
            string query = $"api/app/post-like/post-like/post-like-count-by-post-id?PostId={postId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<List<PostLikeDto>> GetLikeCountByUserIdAsync(Guid UserId)
        {
            string query = $"api/app/post-like/post-like/post-like-count-by-user-id?UserId={UserId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<List<PostLikeDto>> GetLikeListByPostIdAsync(Guid postId)
        {
            string query = $"api/app/post-like/post-like/post-like-list-by-post-id?PostId={postId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<List<PostLikeDto>> GetLikeListByUserIdAsync(Guid UserId)
        {
            string query = $"api/app/post-like/post-like/post-like-list-by-user-id?UserId{UserId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<List<PostLikeDto>> PostPostLikeAsync(Guid postId)
        {
            string query = $"api/app/post-like/post-like";
            var response = await _httpClient.PostAsJsonAsync(query, postId);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }
    }
}
