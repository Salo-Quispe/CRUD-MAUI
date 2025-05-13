using Microsoft.Extensions.Logging;

namespace squispe5A
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
            string dbPath = FileAccesHelper.GetLocalFolderPath("personas.db");
            builder.Services.AddSingleton<Repository.PersonRepository>(s => ActivatorUtilities.CreateInstance<Repository.PersonRepository>(s,dbPath)); 
#endif

            return builder.Build();
        }
    }
}
