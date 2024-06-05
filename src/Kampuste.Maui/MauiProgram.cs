using IdentityModel.OidcClient;
using Kampuste.Maui.Services.OpenIddict;
using Kampuste.Maui.Services.Storage;
//using Kampuste.Maui.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;
using Volo.Abp.Autofac;
using Microsoft.Extensions.FileProviders;
using Volo.Abp;
using Microsoft.Maui.LifecycleEvents;

namespace Kampuste.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            //var a = Assembly.GetExecutingAssembly();
            //using var stream = a.GetManifestResourceStream("Kampuste.Maui.appsettings.json");
            //var config = new ConfigurationBuilder()
            //    .AddJsonStream(stream)
            //    .Build();
            //builder.Configuration.AddConfiguration(config);

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                }).ConfigureContainer(new AbpAutofacServiceProviderFactory(new Autofac.ContainerBuilder()));
            builder.Services.AddApplication<KampusteMauiAppModule>(options =>
            {
                options.Services.ReplaceConfiguration(builder.Configuration);
            });

            builder.Services.AddMauiBlazorWebView();
           


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif


            //builder.Services.AddSingleton<IConfiguration>(config);
            //builder.Services.AddSingleton<IOpenIddictService, OpenIddictService>();
            //builder.Services.AddSingleton<ISecureStorage, StorageService>();
            //builder.Services.AddTransient<WebAuthenticatorBrowser>();
            //builder.Services.AddSingleton<ICurrentUser, CurrentUser>();
            //builder.Services.AddSingleton<ICurrentUser, UserService>();

            //builder.Services.ICurrentPrincipalAccessor
            //builder.Services.AddTransient<OidcClient>(OpenIddictService.);
            var app = builder.Build();

            app.Services.GetRequiredService<IAbpApplicationWithExternalServiceProvider>().Initialize(app.Services);
            var assembly = typeof(App).GetTypeInfo().Assembly;
            builder.Configuration.AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false, false);
            return app;
            //return builder.Build();
        }
        //public static HttpClient GetHttpClient()
        //{
        //    var devSslHelper = new DevHttpsConnectionHelper();
        //    devSslHelper.HttpClient.Timeout = TimeSpan.FromSeconds(60);
        //    return devSslHelper.HttpClient;
        //}



    }
}
