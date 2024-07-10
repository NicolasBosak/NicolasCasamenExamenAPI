using Newtonsoft.Json;
using NicolasCasamenExamenAPI.NCModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicolasCasamenExamenAPI.NCServices
{
    public class NCPokeServices
    {
        private readonly HttpClient _httpClient;

        public NCPokeServices()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }
        public async Task<NCPokemon> GetPokemonAsync(string name)
        {
        NCPokemon pokemon = null;
           
        HttpResponseMessage response = await _httpClient.GetAsync($"pokemon/{name.ToLower()}");

        if (response.IsSuccessStatusCode)
        {
            string responseString = await response.Content.ReadAsStringAsync();
            pokemon = JsonConvert.DeserializeObject<NCPokemon>(responseString);
        }
                
        return pokemon;
        }
    }
}

