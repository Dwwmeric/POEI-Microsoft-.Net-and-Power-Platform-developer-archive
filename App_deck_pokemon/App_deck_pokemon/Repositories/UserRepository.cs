using App_deck_pokemon.Models;
using App_deck_pokemon.Tools;
using Microsoft.EntityFrameworkCore;

namespace App_deck_pokemon.Repositories
{
    public class UserRepository : BaseRepositories<User>
    {
        public UserRepository(DataDbContext dataContext) : base(dataContext)
        {
        }

        public override bool Delete(User element)
        {
            _dataContext.User.Remove(element);
            return _dataContext.SaveChanges() > 0;
        }

        public override List<User> FindAll()
        {
            return _dataContext.User.Include(up => up._userPokemon ).ToList();
        }

        public override User FindById(int id)
        {
            return _dataContext.User.FirstOrDefault(u => u.Id == id);
        }

        public override bool Save(User element)
        {
            _dataContext.User.Add(element);
            return _dataContext.SaveChanges() > 0;
        }

        public override List<User> SearchAll(Func<User, bool> SearchMethod)
        {
            return _dataContext.User.Where(SearchMethod).ToList();
        }

        public override User SearchOne(Func<User, bool> SearchMethod)
        {
            return _dataContext.User.FirstOrDefault(SearchMethod);
        }
    }
}
