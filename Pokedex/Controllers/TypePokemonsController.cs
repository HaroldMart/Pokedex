using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class TypePokemonsController : Controller
    {
        private readonly TypePokemonServices _typePokemonServices;
        private getColors color;
        public TypePokemonsController(ApplicationContext dbContext)
        {
            _typePokemonServices = new(dbContext);
            color = new();
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.color = this.color;
            return View(await _typePokemonServices.GetAllTypePokemons());
        }
        public async Task<IActionResult> Save()
        {
            ViewBag.color = this.color;
            return View("SaveTypePokemon", new TypePokemonViewModel()); 
        }

        [HttpPost]
        public async Task<IActionResult> SaveTypePokemon(TypePokemonViewModel vm)
        {
            ViewBag.color = this.color;
            if (!ModelState.IsValid)
            {
                return View("SaveTypePokemon", vm);
            }
            await _typePokemonServices.Add(vm);
            return RedirectToRoute(new { Controller = "TypePokemons", Action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.color = this.color;
            return View("SaveTypePokemon", await _typePokemonServices.GetByIdTypePokemonViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TypePokemonViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTypePokemon", vm);
            }
            await _typePokemonServices.Update(vm);
            return RedirectToRoute(new { Controller = "TypePokemons", Action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _typePokemonServices.GetByIdTypePokemonViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var typePokemon = await _typePokemonServices.ValidDelete(id);
            if(typePokemon.Count == 0)
            {
                await _typePokemonServices.Delete(id);
                return RedirectToRoute(new { Controller = "TypePokemons", Action = "Index" });
            } else
            {
                return RedirectToRoute(new { Controller = "TypePokemons", Action = "noValidPokemon" });
            }
          
        }

        public IActionResult noValidPokemon()
        {
            return View();
        }
    }
}
