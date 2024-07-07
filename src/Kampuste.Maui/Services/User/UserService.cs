using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;
//using Kampuste.Maui.Services.User

namespace Kampuste.Maui.Services.User
{
    public class UserService : IUserService, ITransientDependency
    {
        private readonly HttpClient _httpClient;
        private readonly ISecureStorage _storageService;
        private readonly IConfiguration _configuration;

        public UserService(HttpClient httpClient, ISecureStorage storageService, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _storageService = storageService;
            _configuration = configuration;
        }

        public async Task<CurrentUsersDetailsDto> CurrentUserDetails()
        {

            var accessToken = await _storageService.GetAsync("AccessToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                return null;
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _configuration["ApiEndpoints:GetCurrentUserDetails"]);
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CurrentUsersDetailsDto>();
            }

            return null;

        }
        public async Task<bool> CheckUserAuthenticationAsync()
        {
            var accessToken = await _storageService.GetAsync("AccessToken");

            if (string.IsNullOrEmpty(accessToken))
            {
                return false;
            }

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _configuration["ApiEndpoints:CheckUserAuthentication"]);
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",accessToken);

            var response = await _httpClient.SendAsync(requestMessage);
            var deneme = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }

            return false;
        }

        public async Task<List<CurrentUsersDetailsDto>> GetUserAsync(Guid Id)
        {
            var response = await _httpClient.GetAsync($"api/app/post/posts/{Id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CurrentUsersDetailsDto>>();
        }

        public async Task<CurrentUsersDetailsDto> PutUserAsync(Guid Id)
        {
            string query = $"api/identity/users/";
            var response = await _httpClient.PutAsJsonAsync(query, Id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CurrentUsersDetailsDto>();
        }

        public async Task<List<CurrentUsersDetailsDto>> GetUserAsync(string filter, string sorting, int skipCount, int MaxResultCount)
        {
            var response = await _httpClient.GetAsync($"api/identity/users?Filter={filter}&Sorting={sorting}&SkipCount={skipCount}&MaxResultCount={MaxResultCount}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CurrentUsersDetailsDto>>();
        }

        public async Task<CurrentUsersDetailsDto> PostUserAsync(CurrentUsersDetailsDto User)
        {
            string query = $"api/identity/users";
            var response = await _httpClient.PostAsJsonAsync(query, User);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync< CurrentUsersDetailsDto > ();
        }

        public async Task<CurrentUsersDetailsDto> DeleteUserAsync(Guid Id)
        {
            string query = $"api/identity/users/{Id}";
            var response = await _httpClient.DeleteAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CurrentUsersDetailsDto>();
        }

        public async Task<List<CurrentUsersDetailsDto>> GetUserRolesAsync(Guid Id)
        {
            string query = $"api/identity/users/{Id}/roles";
            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<CurrentUsersDetailsDto>>();
        }

        public Task<List<CurrentUsersDetailsDto>> PutUserRolesAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CurrentUsersDetailsDto>> GetUserByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<List<CurrentUsersDetailsDto>> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }

    public class CurrentUserDto
    {
        public bool IsAuthenticated { get; set; }
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
