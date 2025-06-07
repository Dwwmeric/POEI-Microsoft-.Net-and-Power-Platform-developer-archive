using System.ComponentModel.DataAnnotations.Schema;

namespace App_deck_pokemon.Models
{
    [Table("user_pokemon")]
    public class UserPokemon
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        [Column("pokemon_id")]
        public int PokemonId { get; set; }

        [ForeignKey("PokemonId")]
        public Pokemon pokemon { get; set; }
    }
}
