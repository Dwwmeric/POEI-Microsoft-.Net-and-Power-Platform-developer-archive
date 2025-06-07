using System.ComponentModel.DataAnnotations.Schema;

namespace App_deck_pokemon.Models
{
    [Table("pokemon")]
    public class Pokemon
    {
            [Column("id")]
            public int Id { get; set; }

            [Column("full_name")]
            public string FullName { get; set; }

            public List<UserPokemon> _userPokemon { get; set; }
            public Pokemon()
            {
                _userPokemon = new List<UserPokemon>();
            }
    }
}
