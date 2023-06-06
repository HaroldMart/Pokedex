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

            modelBuilder.Entity<Pokemon>()
                .HasOne(pokemon => pokemon.Type1)
                .WithMany(type1 => type1.Pokemons1)
                .HasForeignKey(pokemon => pokemon.IdType1)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Pokemon>()
               .HasOne(pokemon => pokemon.Type2)
               .WithMany(type2 => type2.Pokemons2)
               .HasForeignKey(pokemon => pokemon.IdType2)
               .OnDelete(DeleteBehavior.ClientSetNull);

            #endregion

            #region property configuration

            #region Pokemon
            modelBuilder.Entity<Pokemon>()
                .Property(pokemon => pokemon.Name)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #region Region
            modelBuilder.Entity<Region>()
                .Property(region => region.Name)
                .IsRequired().
                HasMaxLength(150);
            #endregion

            #region TypePokemon
            modelBuilder.Entity<TypePokemon>()
                .Property(type => type.Name)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #endregion
        }
    }
}
