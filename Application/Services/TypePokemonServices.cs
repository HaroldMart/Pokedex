using Application.Repository;
using Application.ViewModels;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TypePokemonServices
    {
        private readonly TypePokemonRepository typePokemonRepository;
        public TypePokemonServices(ApplicationContext dbContext)
        {
            typePokemonRepository = new(dbContext);
        }

        public async Task<List<TypePokemonViewModel>> GetAllTypePokemons()
        {
            var typePokemonList = await typePokemonRepository.GetAllAsync();

            return typePokemonList.Select(typePokemon => new TypePokemonViewModel
            {
                Id = typePokemon.Id,
                Name = typePokemon.Name,
                Pokemons1 = typePokemon.Pokemons1,
                Pokemons2 = typePokemon.Pokemons2
            }).ToList();
        }
    }
}
