using App_deck_pokemon.Models;

namespace App_deck_pokemon.DTOs
{
    public class ImagePokemonRequestDTO
    {

        public string Url { get; set; }

        public Pokemon Pokemon { get; set; }
    }
}
