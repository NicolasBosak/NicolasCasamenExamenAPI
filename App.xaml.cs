namespace NicolasCasamenExamenAPI
{
    public partial class App : Application
    {
        public static NCPokemonRepository Pokemonrepo { get; private set; }
        public App(NCPokemonRepository repo)
        {
            InitializeComponent();
            MainPage = new AppShell();

            Pokemonrepo = repo;
        }
    }
}
