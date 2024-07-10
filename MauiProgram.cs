using SQLite;

namespace NicolasCasamenExamenAPI
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
            string dbPath = FileAccessHelper.GetLocalFilePath("NCPokemon.db3");
            builder.Services.AddSingleton<NCPokemonRepository>(s => ActivatorUtilities.CreateInstance<NCPokemonRepository>(s, dbPath));
#endif

            return builder.Build();
        }
    }
}
