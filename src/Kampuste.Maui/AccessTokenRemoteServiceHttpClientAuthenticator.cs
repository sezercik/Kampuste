using IdentityModel.Client;
using IdentityModel.OidcClient;
using System.IdentityModel.Tokens.Jwt;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.Authentication;
using DependencyAttribute = Volo.Abp.DependencyInjection.DependencyAttribute;
using Kampuste.Maui.Services.OpenIddict;
using Microsoft.Extensions.Configuration;

namespace Kampuste.Maui
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IRemoteServiceHttpClientAuthenticator))]
    public class AccessTokenRemoteServiceHttpClientAuthenticator : IRemoteServiceHttpClientAuthenticator, ITransientDependency
    {
        //protected OidcClient OidcClient { get; }
        private readonly IConfiguration _configuration;
        private readonly ISecureStorage _storageService;
        public AccessTokenRemoteServiceHttpClientAuthenticator(IConfiguration configuration, ISecureStorage storageService)
        {
            //OidcClient = oidcClient;
            _configuration = configuration;
            _storageService = storageService;
        }

        public OidcClient CreateOidcClient()
        {
            var oIddict = _configuration.GetSection(nameof(OpenIddictSettings)).Get<OpenIddictSettings>();
            var options = new OidcClientOptions
            {
                Authority = oIddict.AuthorityUrl,
                ClientId = oIddict.ClientId,
                Scope = oIddict.Scope,
                RedirectUri = oIddict.RedirectUri,
                ClientSecret = oIddict.ClientSecret,
                //PostLogoutRedirectUri = oIddict.RedirectUri,

                PostLogoutRedirectUri = oIddict.PostLogoutRedirectUri,
                Browser = new WebAuthenticatorBrowser()
                //HttpClientFactory = options => GetHttpClient()
            };
            options.BackchannelHandler = new HttpClientHandler() { ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true };
            options.Policy.Discovery.ValidateIssuerName = false;
            options.Policy.Discovery.ValidateEndpoints = false;


            return new OidcClient(options);
        }

        public async Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
        {
            OidcClient OidcClient = CreateOidcClient();
            //var currentAccessToken = await SecureStorage.GetAsync("AccessToken");
            var currentAccessToken =  await _storageService.GetAsync("AccessToken");
            if (!currentAccessToken.IsNullOrEmpty())
            {
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(currentAccessToken) as JwtSecurityToken;
                if (jwtToken.ValidTo <= DateTime.UtcNow)
                {
                    var refreshToken = await SecureStorage.GetAsync("RefreshToken");
                    if (!refreshToken.IsNullOrEmpty())
                    {
                        var refreshResult = await OidcClient.RefreshTokenAsync(refreshToken);

                        await SecureStorage.SetAsync("AccessToken", refreshResult.AccessToken);
                        await SecureStorage.SetAsync("RefreshToken", refreshResult.RefreshToken);

                        context.Request.SetBearerToken(refreshResult.AccessToken);
                    }
                    else
                    {
                        var loginResult = await OidcClient.LoginAsync(new LoginRequest());

                        await SecureStorage.SetAsync("AccessToken", loginResult.AccessToken);
                        await SecureStorage.SetAsync("RefreshToken", loginResult.RefreshToken);

                        context.Request.SetBearerToken(loginResult.AccessToken);
                    }
                }

                context.Request.SetBearerToken(currentAccessToken);
            }
        }
    }
}

