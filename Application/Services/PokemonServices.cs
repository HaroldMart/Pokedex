﻿using Application.Repository;
using Application.ViewModels;
using Database;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
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
        private getColors color;
        public PokemonServices(ApplicationContext dbContext) { 
            pokemonRepository = new(dbContext);
            color = new getColors();
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
                Type2 = pokemon.Type2,
                ColorType1 = color.ChangeColorType(pokemon.Type1.Color),
                ColorType2 = color.ChangeColorType(pokemon.Type2.Color)
            }).ToList();
        }

        public async Task Add(SavePokemonViewModel vm)
        {
            Pokemon pokemon = new()
            {
                Name = vm.Name,
                ImagePath = vm.ImagePath,
                Id_region = vm.Id_region,
                IdType1 = vm.IdType1,
                IdType2 = vm.IdType2
            };

            await pokemonRepository.AddAsync(pokemon);
        }

        public async Task Update(SavePokemonViewModel vm)
        {
            Pokemon pokemon = await pokemonRepository.GetByIdAsync(vm.Id);
                pokemon.Name = vm.Name;
                pokemon.ImagePath = vm.ImagePath;
                pokemon.Id_region = vm.Id_region;
                pokemon.IdType1 = vm.IdType1;
                pokemon.IdType2 = vm.IdType2;

                await pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task Delete(int id)
        {
            Pokemon pokemon = await pokemonRepository.GetByIdAsync(id);
            await pokemonRepository.DeleteAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> GetByIdSavePokemonViewModel(int id)
        {
            var pokemon = await pokemonRepository.GetByIdAsync(id);
            SavePokemonViewModel vm = new()
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,
                Id_region = pokemon.Id_region,
                IdType1 = pokemon.IdType1,
                IdType2 = pokemon.IdType2
            };
            return vm;
        }

        public async Task<List<PokemonViewModel>> GetAllViewModelWithFilters(FilterPokemonViewModel filters)
        {
            var pokemonList = await pokemonRepository.GetAllAsync();

            var ListViewModels = pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,
                Type1 = pokemon.Type1,
                Type2 = pokemon.Type2,
                Region = pokemon.Region,
                ColorType1 = color.ChangeColorType(pokemon.Type1.Color),
                ColorType2 = color.ChangeColorType(pokemon.Type2.Color)

            }).ToList();

            if (filters.Region != null)
            {
                ListViewModels = ListViewModels.Where(pokemon => pokemon.Region.Id == filters.Region.Value).ToList();
            }

            return ListViewModels;
        }

        public async Task<List<PokemonViewModel>> GetAllViewModelWithSearch(string name)
        {
            var pokemonList = await pokemonRepository.GetAllAsync();

            var ListViewModels = pokemonList.Select(pokemon => new PokemonViewModel
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImagePath = pokemon.ImagePath,
                Type1 = pokemon.Type1,
                Type2 = pokemon.Type2,
                Region = pokemon.Region,
                ColorType1 = color.ChangeColorType(pokemon.Type1.Color),
                ColorType2 = color.ChangeColorType(pokemon.Type2.Color)

            }).ToList();

            if (name != null)
            {
                ListViewModels = ListViewModels.Where(pokemon => pokemon.Name == name).ToList();
            }

            return ListViewModels;
        }

    }
}
