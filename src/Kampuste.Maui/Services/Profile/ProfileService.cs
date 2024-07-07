using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Account;

namespace Kampuste.Maui.Services.Profile
{
    internal class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;

        public ProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProfileDto>> GetProfileAsync()
        {
            string query = $"api/account/my-profile";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ProfileDto>>();
        }

        public async Task<List<ProfileDto>> PostProfileAsync(ProfileDto postReply)
        {
            string query = $"api/account/my-profile/change-password";
            var response = await _httpClient.PostAsJsonAsync(query, postReply);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ProfileDto>>();
        }

        public async Task<List<ProfileDto>> PutProfileAsync(ProfileDto postReply)
        {
            string query = $"api/account/my-profile";
            var response = await _httpClient.PutAsJsonAsync(query,postReply);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ProfileDto>>();
        }
    }
}
