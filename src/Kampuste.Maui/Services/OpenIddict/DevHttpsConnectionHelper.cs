using Microsoft.Maui.Controls;

namespace Kampuste.Maui.Services.OpenIddict
{
    public class DevHttpsConnectionHelper
    {
        public DevHttpsConnectionHelper()
        {
            LazyHttpClient = new Lazy<HttpClient>(() => new HttpClient(GetPlatformMessageHandler())
            {
                BaseAddress = new Uri("https://szrakoraler.dev")
            });
        }
        public string DevServerRootUrl { get; }

        private Lazy<HttpClient> LazyHttpClient;
        public HttpClient HttpClient => LazyHttpClient.Value;

        public HttpMessageHandler? GetPlatformMessageHandler()
        {
            var httpsClientHandlerService = new HttpsClientHandlerService();
            return httpsClientHandlerService.GetPlatformMessageHandler();
        }
    }
}