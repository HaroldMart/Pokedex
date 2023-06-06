using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly PokemonServices _pokemonServices;
        private GetAllProperties _getAll;
        getColors color;

        public PokemonsController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
            _getAll = new(dbContext);
            color = new();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.color = this.color;
            return View(await _pokemonServices.GetAllPokemons());
        }

        public async Task<IActionResult> Save()
        {
            var getAllRegions = await _getAll.AllRegions();
            var getAllTypePokemon = await _getAll.AllTypesPokemon();
            ViewBag.getAllRegions = getAllRegions;
            ViewBag.getAllTypePokemon = getAllTypePokemon;

            return View("SavePokemon", new SavePokemonViewModel());;
        }

        [HttpPost]
        public async Task<IActionResult> SavePokemon(SavePokemonViewModel vm)
        {
            var getAllRegions = await _getAll.AllRegions();
            var getAllTypePokemon = await _getAll.AllTypesPokemon();
            ViewBag.getAllRegions = getAllRegions;
            ViewBag.getAllTypePokemon = getAllTypePokemon;

            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            await _pokemonServices.Add(vm);
            return RedirectToRoute(new { Controller = "Pokemons", Action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {

            var getAllRegions = await _getAll.AllRegions();
            var getAllTypePokemon = await _getAll.AllTypesPokemon();
            ViewBag.getAllRegions = getAllRegions;
            ViewBag.getAllTypePokemon = getAllTypePokemon;
            return View("SavePokemon", await _pokemonServices.GetByIdSavePokemonViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            await _pokemonServices.Update(vm);
            return RedirectToRoute(new { Controller = "Pokemons", Action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonServices.GetByIdSavePokemonViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonServices.Delete(id);
            return RedirectToRoute(new { Controller = "Pokemons", Action = "Index" });
        }
    }
}
