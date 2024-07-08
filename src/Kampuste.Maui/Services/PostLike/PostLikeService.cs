using Kampus.PostsLikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Kampuste.Maui.Services.PostLike
{
    [Volo.Abp.DependencyInjection.Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IPostLikeService))]
    public class PostLikeService : ITransientDependency, IPostLikeService
    {
        private readonly HttpClient _httpClient;
        private readonly ISecureStorage _storageService;

        public PostLikeService(HttpClient httpClient, ISecureStorage storageService)
        {
            _httpClient = httpClient;
            _storageService = storageService;
        }
        public async Task<List<PostLikeDto>> DeletePostLikeAsync(Guid postId)
        {
            string query = $"api/app/post-like/post-like?PostId={postId}";
            var response = await _httpClient.DeleteAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<int> GetLikeCountByPostIdAsync(Guid postId)
        {
            string query = $"api/app/post-like/post-like-count-by-post-id?PostId={postId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<List<PostLikeDto>> GetLikeCountByUserIdAsync(Guid UserId)
        {
            string query = $"api/app/post-like/post-like-count-by-user-id?UserId={UserId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<List<PostLikeDto>> GetLikeListByPostIdAsync(Guid postId)
        {
            string query = $"api/app/post-like/post-like-list-by-post-id?PostId={postId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<List<PostLikeDto>> GetLikeListByUserIdAsync(Guid UserId)
        {
            string query = $"api/app/post-like/post-like-list-by-user-id?UserId{UserId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostLikeDto>>();
        }

        public async Task<bool> PostPostLikeAsync(Guid postId)
        {
            var accessToken = await _storageService.GetAsync("AccessToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                return false;
            }

            string query = "api/app/post-like/post-like";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, query)
            {
                Content = JsonContent.Create(new { postId })
            };
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(requestMessage);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }

            // Optionally log or handle the error response content here.
            Console.WriteLine(responseContent);

            return false;
        }


    }
}
