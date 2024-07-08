using C1.Blazor.DataFilter;
using Kampus.PostQuotes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace Kampuste.Maui.Services.PostQuote
{
    [Volo.Abp.DependencyInjection.Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IPostQuoteService))]
    public class PostQuoteService : ITransientDependency, IPostQuoteService
    {
        private readonly HttpClient _httpClient;

        public PostQuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PostQuoteDto>> DeletePostQuoteAsync(Guid postQuoteId)
        {
            string query = $"api/app/post-quote/post-quote/{postQuoteId}";
            var response = await _httpClient.DeleteAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostQuoteDto>>();
        }

        public async Task<List<PostQuoteDto>> GetPostQuoteByIdAsync(Guid postQuoteId)
        {
            
            string query = $"api/app/post-quote/post-quote-by-id/{postQuoteId}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostQuoteDto>>();
        }

        public async Task<PagedResultDto<PostQuoteDto>> GetPostQuoteListAsync(Guid postQuoteId,string filter, string sorting, int skipCount, int maxResultCount)
        {
            string query = $"api/app/post-quote/post-quote-list?QuotedPostId={postQuoteId}&Filter={filter}&Sorting={sorting}&SkipCount={skipCount}&MaxResultCount={maxResultCount}";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PagedResultDto<PostQuoteDto>>();
        }

        public async Task<List<PostQuoteDto>> PostPostQuoteAsync(PostQuoteDto postQuote)
        {
            string query = $"api/app/post-quote/post-quote";
            var response = await _httpClient.PostAsJsonAsync(query, postQuote);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PostQuoteDto>>();
        }

       
    }
}
