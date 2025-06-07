using App_deck_pokemon.DTOs;
using App_deck_pokemon.Models;
using App_deck_pokemon.Repositories;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace App_deck_pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagePokemonController : ControllerBase
    {
        private BlobServiceClient _blobServiceClient;
        private PokemonRepository _pokemonRepository;
        private ImagePokemonRepository _imagePokemonRepository;

        public ImagePokemonController(PokemonRepository pokemonRepository, ImagePokemonRepository imagePokemonRepository)
        {
            _blobServiceClient = new BlobServiceClient("");
            _pokemonRepository = pokemonRepository;
            _imagePokemonRepository = imagePokemonRepository;
        }

        //Créate container
        [Authorize(Policy = "admin")]
        [HttpPost("/container")]
        public IActionResult Post(string name)
        {
            //Créer container
            BlobContainerClient containerClient = _blobServiceClient.CreateBlobContainer(name);
            if (containerClient.Exists())
            {
                return Ok(new { Message = "Container created " + containerClient.Name });
            }
            else
            {
                return Ok(new { message = "Erreur création" });
            }
        }

        [Authorize(Policy = "admin")]
        [HttpPost("/container/{name}/{id_pokemon}/")]
        public IActionResult CreateImg(string name, int id_pokemon, IFormFile image)
        {
            Pokemon pokemon = _pokemonRepository.FindById(id_pokemon);

            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient(name);
            BlobClient blobClient = containerClient.GetBlobClient(image.FileName);
            blobClient.Upload(image.OpenReadStream());

            ImagePokemon pokemonImage = new ImagePokemon()
            {
                Url  = blobClient.Uri.ToString(),
                Pokemon =  pokemon,
            };
            if (_imagePokemonRepository.Save(pokemonImage))
            {
                return Ok(new ImagePokemonResponceDTO() { Id = pokemonImage.Id , Url = pokemonImage.Url , PokemonId = pokemonImage.PokemonId , pokemon = pokemonImage.Pokemon });
            }
            return StatusCode(500, new { Message = "Erreur server image pokemon create" });

        }

    }
}
