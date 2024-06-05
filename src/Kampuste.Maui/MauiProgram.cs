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


            var app = builder.Build();

            app.Services.GetRequiredService<IAbpApplicationWithExternalServiceProvider>().Initialize(app.Services);
            var assembly = typeof(App).GetTypeInfo().Assembly;
            builder.Configuration.AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false, false);
            return app;
        }

    }
}
