using App_deck_pokemon.Models;
using Microsoft.EntityFrameworkCore;

namespace App_deck_pokemon.Tools
{
    public class DataDbContext : DbContext
    {
        public DbSet<ImagePokemon> ImagePokemons { get; set; }

        public DbSet<Pokemon> Pokemon { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<UserPokemon> UserPokemon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:utopios-m2i.database.windows.net,1433;Initial Catalog=poke-api-eric;Persist Security Info=False;User ID=m2iformation;Password=Toto.Tata12/;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
