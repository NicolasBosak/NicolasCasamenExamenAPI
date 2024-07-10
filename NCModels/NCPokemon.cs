﻿using SQLite;

namespace NicolasCasamenExamenAPI.NCModels
{
    [Table("Pokemon")]
    public class NCPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
