using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace FloraSense
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var configuration = new ConfigurationBuilder()
                .AddJsonStream(assembly.GetManifestResourceStream("FloraSense.appsettings.json")
                    ?? throw new ArgumentException("Unable to find resource appsettings.json"))
                .Build();

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Configuration.AddConfiguration(configuration);

            DependencyInjector.Inject(builder.Services, builder.Configuration);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
