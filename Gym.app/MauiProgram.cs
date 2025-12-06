using Edus.Bll.Interface;
using Edus.Bll.Model;
using Edus.Bll.Service;
using Edus.Share.Model;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Gym.app.Theme;
using Microsoft.Maui.Storage;
using Edus.app.Data.Services;

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

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();

            // ThemeState: arrancar siguiendo el sistema
            builder.Services.AddSingleton<ThemeState>(sp =>
            {
                var theme = new ThemeState();
                // Fuerza seguir sistema al iniciar (puedes condicionar según preferencia guardada)
                theme.SetSystem();
                return theme;
            });

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(new cApiUrl().getWebApiUrl()) });
            builder.Services.AddScoped<IClienteFarmacia, sClienteFarmacia>();
            builder.Services.AddScoped<IMedicamento, sMedicamento>();
          

            return builder.Build();
        }
    }
}
