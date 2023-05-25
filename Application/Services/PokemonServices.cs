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
    public class PokemonServices
    {
        private readonly PokemonRepository pokemonRepository;
        public PokemonServices(ApplicationContext dbContext) { 
            pokemonRepository = new(dbContext);
        }

        public async Task<List<PokemonViewModel>> GetAllPokemons()
        {
            var pokemonList = await pokemonRepository.GetAllAsync();

            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,
                Region = pokemon.Region,
                Type1 = pokemon.Type1,
                Type2 = pokemon.Type2
            }).ToList();
        }
    }
}
