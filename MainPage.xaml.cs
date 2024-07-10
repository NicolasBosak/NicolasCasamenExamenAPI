using NicolasCasamenExamenAPI.NCModels;
using NicolasCasamenExamenAPI.NCServices;
namespace NicolasCasamenExamenAPI
{
    public partial class MainPage : ContentPage
    {
        private NCPokemonRepository _pokemonRepository;

        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "pokemon.db3");
            _pokemonRepository = new NCPokemonRepository(dbPath);
            GetAllPokemon();
        }

        private async void OnSearchButtonClicked(object sender, EventArgs e)
        {
            string pokemonName = pokemonEntry.Text;

            if (!string.IsNullOrEmpty(pokemonName))
            {
                NCPokeServices client = new NCPokeServices();
                NCPokemon pokemon = await client.GetPokemonAsync(pokemonName);

                if (pokemon != null)
                {
                    nameLabel.Text = $"Name: {pokemon.Name}";
                    heightLabel.Text = $"Height: {pokemon.Height} Pulgadas";
                    weightLabel.Text = $"Weight: {pokemon.Weight} Libras";

                    await _pokemonRepository.AddNewPokemon(pokemon);
                    statusMessage.Text = _pokemonRepository.StatusMessage;
                }
                else
                {
                    nameLabel.Text = "Pokémon not found";
                    heightLabel.Text = string.Empty;
                    weightLabel.Text = string.Empty;
                }
            }
        }

        private async void GetAllPokemon()
        {
            List<NCPokemon> allPokemon = await _pokemonRepository.GetAllPokemon();
            ListaPokemon.ItemsSource = allPokemon;
        }

        private async void OnGetButtonClicked(object sender, EventArgs e)
        {
            List<NCPokemon> allPokemon = await _pokemonRepository.GetAllPokemon();
            ListaPokemon.ItemsSource = allPokemon;
            GetAllPokemon();
        }
    }

}
