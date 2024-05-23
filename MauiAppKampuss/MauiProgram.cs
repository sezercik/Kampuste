using Microsoft.Extensions.Logging;

namespace MauiAppKampuss
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
                });
            // HttpClient'i DI sistemine kaydet
            //builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri("https://api.yourservice.com") });

            // Servisi kaydet
            //builder.Services.AddTransient<YourApiService>();
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
