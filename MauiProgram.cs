using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;


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

            return builder.Build();
        }
    }
}
