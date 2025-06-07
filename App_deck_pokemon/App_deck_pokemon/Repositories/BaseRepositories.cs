using App_deck_pokemon.Tools;

namespace App_deck_pokemon.Repositories
{
    public abstract class BaseRepositories<T>
    {
        protected DataDbContext _dataContext { get; set; }
        protected BaseRepositories(DataDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual bool Update()
        {
            return _dataContext.SaveChanges() > 0;
        }

        public abstract bool Save(T element);

        public abstract T FindById(int id);

        public abstract List<T> FindAll();

        public abstract T SearchOne(Func<T, bool> SearchMethod);

        public abstract List<T> SearchAll(Func<T, bool> SearchMethod);

        public abstract bool Delete(T element);


    }
}
