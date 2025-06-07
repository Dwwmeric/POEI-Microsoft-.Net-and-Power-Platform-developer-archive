using System.ComponentModel.DataAnnotations.Schema;

namespace App_deck_pokemon.Models
{
    [Table("user")]
    public class User
    {
      
            [Column("id")]
            public int Id { get; set; }

            [Column("Last_name")]
            public string LastName { get; set; }

            [Column("first_name")]
            public string FirstName { get; set; }

            [Column("role")]
            public string Role { get; set; }

            [Column("email")]
            public string Email { get; set; }

            [Column("password")]
            public string Password { get; set; }

            public List<UserPokemon> _userPokemon { get; set; }
            public User()
            {
                _userPokemon = new List<UserPokemon>();
            }


    }
}
