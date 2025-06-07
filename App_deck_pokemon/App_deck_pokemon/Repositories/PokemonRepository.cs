using App_deck_pokemon.Models;
using App_deck_pokemon.Tools;
using Microsoft.EntityFrameworkCore;

namespace App_deck_pokemon.Repositories
{
    public class PokemonRepository : BaseRepositories<Pokemon>
    {
        public PokemonRepository(DataDbContext dataContext) : base(dataContext)
        {
        }

        public override bool Delete(Pokemon element)
        {
            _dataContext.Pokemon.Remove(element);
            return _dataContext.SaveChanges() > 0;
        }

        public override List<Pokemon> FindAll()
        {
            return _dataContext.Pokemon.ToList();
        }

        public override Pokemon FindById(int id)
        {
            return _dataContext.Pokemon.Include(up => up._userPokemon).FirstOrDefault(u => u.Id == id);
        }

        public override bool Save(Pokemon element)
        {
            _dataContext.Pokemon.Add(element);
            return _dataContext.SaveChanges() > 0;
        }

        public override List<Pokemon> SearchAll(Func<Pokemon, bool> SearchMethod)
        {
            return _dataContext.Pokemon.Where(SearchMethod).ToList();
        }

        public override Pokemon SearchOne(Func<Pokemon, bool> SearchMethod)
        {
            return _dataContext.Pokemon.FirstOrDefault(SearchMethod);
        }
    }
}
