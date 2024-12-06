using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using TODOApp.Services;
using TODOApp.Views.Home;


namespace TODOApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-brands-400.ttf", "FontAwesomeBrands");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolidIcon");

                }).UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<TODOApiService>();
            builder.Services.AddTransient<HomePage>();

            return builder.Build();
        }
    }
}
