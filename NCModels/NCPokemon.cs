using SQLite;

namespace NicolasCasamenExamenAPI.NCModels
{
    [Table("Pokemon")]
    public class NCPokemon
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
