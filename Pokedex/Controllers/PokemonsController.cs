using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly PokemonServices _pokemonServices;

        public PokemonsController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonServices.GetAllPokemons());
        }

        public IActionResult Save()
        {
            return View("SavePokemon", new SavePokemonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Save(SavePokemonViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View("SavePokemon", vm);
            }
            await _pokemonServices.Add(vm);
            return RedirectToRoute(new { Controller = "Pokemons", Action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
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
