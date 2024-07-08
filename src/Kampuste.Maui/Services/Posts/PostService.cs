using Kampus.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace Kampuste.Maui.Services.Posts
{
    [Volo.Abp.DependencyInjection.Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IPostService))]
    public class PostService : ITransientDependency, IPostService
    {
        private readonly HttpClient _httpClient;
        private readonly ISecureStorage _storageService;
        public PostService(HttpClient httpClient, ISecureStorage storageService)
        {
            _httpClient = httpClient;
            _storageService = storageService;
        }

        public async Task<List<PostDto>> GetPostsAsync()//https://smooth-tahr-perfectly.ngrok-free.app/api/app/post/posts
        {
            var response = await _httpClient.GetAsync("api/app/post/posts");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PagedResultDto<PostDto>>();
            if (result == null)
            {
                throw new InvalidOperationException("The result from the API is null.");
            }

            return result.Items.ToList();
        }

        public async Task<PostDto> GetPostByIdAsync(Guid postId)
        {
            var response = await _httpClient.GetAsync($"api/app/post/posts/{postId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PostDto>();
        }

        public async Task<List<PostDto>> GetPostListByUserIDAsync(Guid userId, string filter, string sorting, int skipCount, int MaxResultCount)
        {
            string query = $"api/app/post/post-list-by-user-id?userId={userId}&Filter={filter}&Sorting={sorting}&SkipCount={skipCount}&MaxResultCount={MaxResultCount}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            var postResponse = await response.Content.ReadFromJsonAsync<PostResponse>();
            return postResponse.Items;
        }

        public async Task<PostDto> PostPostAsync(PostDto post)
        {
            var accessToken = await _storageService.GetAsync("AccessToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                return null;
            }

            string query = $"api/app/post/post";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, query)
            {
                Content = JsonContent.Create(post)
            };
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PostDto>();
        }

        public async Task<PostDto> DeletePostAsync(Guid postId)
        {
            string query = $"api/app/post/{postId}";
            var response = await _httpClient.DeleteAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PostDto>();
        }
    }

    public class PostResponse
    {
        public int TotalCount { get; set; }
        public List<PostDto> Items { get; set; }
    }
}
