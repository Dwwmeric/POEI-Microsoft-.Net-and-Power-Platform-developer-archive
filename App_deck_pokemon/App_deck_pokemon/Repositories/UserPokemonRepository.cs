using App_deck_pokemon.Models;
using App_deck_pokemon.Tools;
using Microsoft.EntityFrameworkCore;

namespace App_deck_pokemon.Repositories
{
    public class UserPokemonRepository : BaseRepositories<UserPokemon>
    {
        public UserPokemonRepository(DataDbContext dataContext) : base(dataContext)
        {
        }

        public override bool Delete(UserPokemon element)
        {
            _dataContext.UserPokemon.Remove(element);
            return _dataContext.SaveChanges() > 0;
        }

        public override List<UserPokemon> FindAll()
        {
            return _dataContext.UserPokemon.Include(p => p.pokemon).Include(u => u.user).ToList();
        }

        public override UserPokemon FindById(int id)
        {
            return _dataContext.UserPokemon.Include(p => p.pokemon).Include(u => u.user).FirstOrDefault(i => i.Id == id);
        }

        public override bool Save(UserPokemon element)
        {
            _dataContext.UserPokemon.Add(element);
            return _dataContext.SaveChanges() > 0; ;
        }

        public override List<UserPokemon> SearchAll(Func<UserPokemon, bool> SearchMethod)
        {
            return _dataContext.UserPokemon.Where(SearchMethod).ToList();
        }

        public override UserPokemon SearchOne(Func<UserPokemon, bool> SearchMethod)
        {
            return _dataContext.UserPokemon.FirstOrDefault(SearchMethod);
        }
    }
}
