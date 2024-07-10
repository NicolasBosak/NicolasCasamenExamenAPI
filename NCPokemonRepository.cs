using NicolasCasamenExamenAPI.NCModels;
using NicolasCasamenExamenAPI.NCServices;
using SQLite;

public class NCPokemonRepository
{
    private string _dbPath;
    public string StatusMessage { get; set; }
    private SQLiteAsyncConnection conn;

    public NCPokemonRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    private async Task Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<NCPokemon>();
    }

    public async Task AddNewPokemon(NCPokemon pokemon)
    {
        int result = 0;
        try
        {
            await Init();

            if (pokemon == null || string.IsNullOrEmpty(pokemon.Name))
                throw new Exception("Se necesita un Pokemon");

            result = await conn.InsertAsync(pokemon);
            StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, pokemon.Name);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", pokemon.Name, ex.Message);
        }
    }

    public async Task<List<NCPokemon>> GetAllPokemon()
    {
        try
        {
            await Init();
            return await conn.Table<NCPokemon>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<NCPokemon>();
    }
}
