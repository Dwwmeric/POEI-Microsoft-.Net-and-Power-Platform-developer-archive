using System.ComponentModel.DataAnnotations.Schema;

namespace App_deck_pokemon.Models
{

    [Table("url_pokemon")]
    public class ImagePokemon
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [ForeignKey("PokemonId")]
        public Pokemon Pokemon { get; set; }
    }
}
