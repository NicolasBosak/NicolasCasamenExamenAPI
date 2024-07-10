using NicolasCasamenExamenAPI.NCModels;
using NicolasCasamenExamenAPI.NCServices;
namespace NicolasCasamenExamenAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
                    heightLabel.Text = $"Height: {pokemon.Height}";
                    weightLabel.Text = $"Weight: {pokemon.Weight}";
                }
                else
                {
                    nameLabel.Text = "Pokémon not found";
                    heightLabel.Text = string.Empty;
                    weightLabel.Text = string.Empty;
                }
            }
        }
    }

}
