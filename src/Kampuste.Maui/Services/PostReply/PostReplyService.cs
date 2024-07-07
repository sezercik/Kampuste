using Kampus.PostReplies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Kampuste.Maui.Services.PostReply
{
    internal class PostReplyService : IPostReplyService , ITransientDependency
    {
        private readonly HttpClient _httpClient;

        public PostReplyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PostReplyDto>> DeletePostReplyAsync(Guid postRepliedId)
        {
            string query = $"api/app/post-reply/post-reply/{postRepliedId}";
            var response = await _httpClient.DeleteAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostReplyDto>>();
        }

        public async Task<List<PostReplyDto>> GetPostreplyByIdAsync(Guid postRepliedId)
        {
            var response = await _httpClient.GetAsync($"api/app/post-reply/post-reply-by-id/{postRepliedId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostReplyDto>>();
        }

        public async Task<List<PostReplyDto>> GetPostReplyListAsync(Guid postRepliedId, string filter, string sorting, int skipCount, int maxResultCount)
        {
            var response = await _httpClient.GetAsync($"api/app/post-reply/post-reply-list?RepliedPostId={postRepliedId}&Filter={filter}&Sorting={sorting}&SkipCount={skipCount}&MaxResultCount={maxResultCount}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostReplyDto>>();
        }

        public async Task<List<PostReplyDto>> PostPostReplyAsync(PostReplyDto postReply)
        {
            string query = $"api/app/post/post";
            var response = await _httpClient.PostAsJsonAsync(query, postReply);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostReplyDto>>();
        }
    }
}
