using App_deck_pokemon.DTOs;
using App_deck_pokemon.Models;
using App_deck_pokemon.Repositories;
using App_deck_pokemon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_deck_pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private PokemonRepository _pokemonRepository;

        public PokemonController(PokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        [Authorize(Policy = "admin")]
        [HttpPost("create")]
        public IActionResult CreatePokemon([FromBody] PokemonRequestDTO PokemonRequestDTO)
        {
            Pokemon pokemon = new Pokemon()
            {
               FullName = PokemonRequestDTO.FullName,
            };
            if (_pokemonRepository.Save(pokemon))
            {
                return Ok(new PokemonResponceDTO() { Id = pokemon.Id , FullName = pokemon.FullName});
            }
            return StatusCode(500, new { Message = "Erreur server Pokemon create" });
        }

        [Authorize(Policy = "client")]
        [HttpGet("Read")]
        public IActionResult ReadPokemon()
        {
            List<Pokemon> users = _pokemonRepository.FindAll();
            List<PokemonResponceDTO> reponseDTO = new List<PokemonResponceDTO>();
            users.ForEach(p =>
            {
                reponseDTO.Add(new PokemonResponceDTO()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                });
            });
            return Ok(reponseDTO);
        }

        [Authorize(Policy = "admin")]
        [HttpPut("update/{id}")]
        public IActionResult UpdatePokemon(int id, [FromBody] PokemonRequestDTO PokemonRequestDTO)
        {
            Pokemon pokemon = _pokemonRepository.FindById(id);

            if (pokemon != null)
            {
                pokemon.FullName = PokemonRequestDTO.FullName;
                
                if (_pokemonRepository.Update())
                    return Ok(pokemon);
                return StatusCode(500, new { Message = " Erreur serveur update " });
            }
            return NotFound();
        }

        [Authorize(Policy = "admin")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            Pokemon pokemon = _pokemonRepository.FindById(id);
            if (pokemon != null)
            {
                _pokemonRepository.Delete(pokemon);
                return StatusCode(200, new { Message = "Delete user Ok " });
            }
            return NotFound();
        }

        [Authorize(Policy = "client")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Pokemon pokemon = _pokemonRepository.FindById(id);
            if (pokemon != null)
                return Ok(pokemon);
            return NotFound();
        }

    }
}
