using IdentityModel.OidcClient;
using Kampuste.Maui.Services.OpenIddict;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Kampuste.Maui
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpHttpClientIdentityModelModule),
    typeof(Kampus.KampusHttpApiClientModule)
    )]
    public class KampusMauiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<OidcClientOptions>(configuration.GetSection("Oidc:Options"));

            context.Services.AddTransient<OidcClient>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<OidcClientOptions>>().Value;
                options.Browser = sp.GetRequiredService<WebAuthenticatorBrowser>();
                return new OidcClient(options);
            });
        }
    }
}
