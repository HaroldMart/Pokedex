using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        
        public DbSet<Pokemon> Pokemons { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<TypePokemon> TypePokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API

            #region tables
            modelBuilder.Entity<Pokemon>().ToTable("Pokemons");
            modelBuilder.Entity<Region>().ToTable("Regions");
            modelBuilder.Entity<TypePokemon>().ToTable("TypePokemons");
            #endregion

            #region primary keys
            modelBuilder.Entity<Pokemon>().HasKey(p => p.Id);
            modelBuilder.Entity<Region>().HasKey(r => r.Id);
            modelBuilder.Entity<TypePokemon>().HasKey(t => t.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Region>()
                .HasMany(region => region.Pokemons)
                .WithOne(pokemon => pokemon.Region)
                .HasForeignKey(pokemon => pokemon.Id_region)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TypePokemon>()
                .HasMany(types => types.Pokemons1)
                .WithOne(pokemon => pokemon.Type1)
                .HasForeignKey(pokemon => pokemon.IdType1)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<TypePokemon>()
                .HasMany(types => types.Pokemons2)
                .WithOne(pokemon => pokemon.Type2)
                .HasForeignKey(pokemon => pokemon.IdType2)
                .OnDelete(DeleteBehavior.ClientSetNull);
            #endregion

            #region property configuration

            #region Pokemon
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Name)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.ImagePath)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Id_region)
                .IsRequired();

            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.IdType1)
                .IsRequired();
            #endregion

            #region Region
            modelBuilder.Entity<Region>()
                .Property(region => region.Name)
                .IsRequired();
            #endregion

            #region TypePokemon
            modelBuilder.Entity<TypePokemon>()
                .Property(type => type.Name)
                .IsRequired();
            #endregion

            #endregion
        }
    }
}
