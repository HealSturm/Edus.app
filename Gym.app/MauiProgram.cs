using Edus.Bll.Interface;
using Edus.Bll.Service;
using Edus.Share.Model;

using Microsoft.Extensions.Logging;
using MudBlazor.Services;


namespace Gym.app
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

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            // builder.Services.AddSingleton<IClienteFarmacia, sClienteFarmacia>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7003/") });
           

            return builder.Build();
        }
    }
}
