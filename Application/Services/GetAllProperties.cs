using Application.ViewModels;
using Database;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GetAllProperties
    {
        private readonly PokemonServices _pokemonServices;
        private readonly RegionServices _regionServices;
        private readonly TypePokemonServices _typePokemonServices;

        public GetAllProperties(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
            _regionServices = new(dbContext);
            _typePokemonServices = new(dbContext);
        }

        public async Task<List<RegionViewModel>> AllRegions()
        {
            var listRegions = await _regionServices.GetAllRegions();
            return listRegions;
        }

        public async Task<List<TypePokemonViewModel>> AllTypesPokemon()
        {
            var listTypePokemon = await _typePokemonServices.GetAllTypePokemons();
            return listTypePokemon;
        }
    }
}
