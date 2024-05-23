using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiAppKampuss
{
    public class YourApiService
    {
        private readonly HttpClient _httpClient;

        public YourApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET metodu
        public async Task<List<string>> GetDataAsync()
        {
            var response = await _httpClient.GetAsync("endpoint");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<stringa>>(content);
        }

        // POST metodu
        public async Task PostDataAsync(string data)
        {
            var response = await _httpClient.PostAsJsonAsync("endpoint", data);
            response.EnsureSuccessStatusCode();
        }

        // PUT metodu
        public async Task PutDataAsync(int id, string data)
        {
            var response = await _httpClient.PutAsJsonAsync($"endpoint/{id}", data);
            response.EnsureSuccessStatusCode();
        }

        // DELETE metodu
        public async Task DeleteDataAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"endpoint/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
