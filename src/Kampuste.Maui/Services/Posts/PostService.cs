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
    public class PostService : ITransientDependency
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostDto>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync("api/posts");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<PagedResultDto<PostDto>>();
            return (List<PostDto>)result.Items;
        }

        public async Task<PostDto> GetPostByIdAsync(Guid postId)
        {
            var response = await _httpClient.GetAsync($"api/posts/{postId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PostDto>();
        }
    }
}
