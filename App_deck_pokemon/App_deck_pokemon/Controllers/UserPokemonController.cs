using App_deck_pokemon.DTOs;
using App_deck_pokemon.Models;
using App_deck_pokemon.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App_deck_pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPokemonController : ControllerBase
    {
        private UserPokemonRepository _userPokemonRepository;
        private UserRepository _userRepository;

        public UserPokemonController(UserPokemonRepository userPokemonRepository, UserRepository usersRepository)
        {
            _userPokemonRepository = userPokemonRepository;
            _userRepository = usersRepository;

        }

       /* [HttpPost("catch")]
        public IActionResult CreatePokemon([FromBody] UserPokemonRepository userPokemonRepository)
        {
           *//*  var email = User.FindFirst(ClaimTypes.Email)?.Value;



            Pokemon pokemon = new Pokemon()
            {
                FullName = PokemonRequestDTO.FullName,
            };
            if (_pokemonRepository.Save(pokemon))
            {
                return Ok(new PokemonResponceDTO() { Id = pokemon.Id, FullName = pokemon.FullName });
            }
            return StatusCode(500, new { Message = "Erreur server Pokemon create" });*//*
        }*/
    }
}
