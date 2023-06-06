using Application.Repository;
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
    public class TypePokemonServices
    {
        private readonly TypePokemonRepository typePokemonRepository;
        private readonly PokemonRepository pokemonRepository;
        public TypePokemonServices(ApplicationContext dbContext)
        {
            typePokemonRepository = new(dbContext);
            pokemonRepository = new(dbContext);
        }

        public async Task<List<TypePokemonViewModel>> GetAllTypePokemons()
        {
            var typePokemonList = await typePokemonRepository.GetAllAsync();

            return typePokemonList.Select(typePokemon => new TypePokemonViewModel
            {
                Id = typePokemon.Id,
                Name = typePokemon.Name,
                Color = typePokemon.Color
            }).ToList();
        }

        public async Task Add(TypePokemonViewModel vm)
        {
            TypePokemon typePokemon = new()
            {
                Name = vm.Name,
                Color = vm.Color,
            };

            await typePokemonRepository.AddAsync(typePokemon);
        }

        public async Task Update(TypePokemonViewModel vm)
        {
            TypePokemon typePokemon = await typePokemonRepository.GetByIdAsync(vm.Id);
            typePokemon.Name = vm.Name;
            typePokemon.Color = vm.Color;

            await typePokemonRepository.UpdateAsync(typePokemon);
        }

        public async Task Delete(int id)
        {
            TypePokemon yypePokemon = await typePokemonRepository.GetByIdAsync(id);

            await typePokemonRepository.DeleteAsync(yypePokemon);
        }

        public async Task<List<Pokemon>> ValidDelete(int id)
        {
            var pokemons = await pokemonRepository.GetAllAsync();

            List<Pokemon> havePokemon = pokemons.Where(p => p.IdType1 == id || p.IdType2 == id).ToList();

            return havePokemon;
        }

        public async Task<TypePokemonViewModel> GetByIdTypePokemonViewModel(int id)
        {
            var typePokemon = await typePokemonRepository.GetByIdAsync(id);
            TypePokemonViewModel vm = new()
            {
                Id = typePokemon.Id,
                Name = typePokemon.Name,
                Color = typePokemon.Color
            };
            return vm;
        }

    }
}
