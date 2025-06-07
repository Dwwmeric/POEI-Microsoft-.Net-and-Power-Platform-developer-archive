using App_deck_pokemon.Models;
using App_deck_pokemon.Tools;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App_deck_pokemon.Repositories
{
    public class ImagePokemonRepository : BaseRepositories<ImagePokemon>
    {
        public ImagePokemonRepository(DataDbContext dataContext) : base(dataContext)
        {
        }

        public override bool Delete(ImagePokemon element)
        {
            _dataContext.ImagePokemons.Remove(element);
            return _dataContext.SaveChanges() > 0;
        }

        public override List<ImagePokemon> FindAll()
        {
            return _dataContext.ImagePokemons.Include(I => I.Pokemon).ToList();
        }

        public override ImagePokemon FindById(int id)
        {
            return _dataContext.ImagePokemons.FirstOrDefault(u => u.Id == id);
        }

        public override bool Save(ImagePokemon element)
        {
            _dataContext.ImagePokemons.Add(element);
            return _dataContext.SaveChanges() > 0;
        }

        public override List<ImagePokemon> SearchAll(Func<ImagePokemon, bool> SearchMethod)
        {
            return _dataContext.ImagePokemons.Where(SearchMethod).ToList();
        }

        public override ImagePokemon SearchOne(Func<ImagePokemon, bool> SearchMethod)
        {
            return _dataContext.ImagePokemons.FirstOrDefault(SearchMethod);
        }
    }
}
