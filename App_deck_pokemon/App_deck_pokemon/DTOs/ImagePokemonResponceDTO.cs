using App_deck_pokemon.Controllers;
using App_deck_pokemon.Models;

namespace App_deck_pokemon.DTOs
{
    public class ImagePokemonResponceDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }


        public  int PokemonId { get; set; }

        public Pokemon pokemon { get; set; }
    }
}
