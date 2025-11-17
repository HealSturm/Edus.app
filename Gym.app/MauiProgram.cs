using Edus.Bll.Interface;
using Edus.Bll.Model;
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

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(new cApiUrl().getWebApiUrl()) });
            builder.Services.AddScoped<IClienteFarmacia, sClienteFarmacia>();
            builder.Services.AddScoped<IMedicamento, sMedicamento>();


            return builder.Build();
        }
    }
}
