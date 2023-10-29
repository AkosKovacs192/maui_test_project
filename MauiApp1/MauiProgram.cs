using MauiApp1.Pages.ViewModels;
using MauiApp1.Pages.Views;
using MauiApp1.Services;
using Microsoft.Extensions.Logging;

namespace MauiApp1
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
                    fonts.AddFont("Joyful.otf", "joyful");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            //httpclient needs to be singleton
            builder.Services.AddSingleton<MyHttpClient>();


            
            builder.Services.AddTransient<DogsView>();
            builder.Services.AddTransient<DogsViewModel>();
            builder.Services.AddTransient<WelcomeView>();
            builder.Services.AddTransient<WelcomeViewModel>();

            return builder.Build();
        }
    }
}