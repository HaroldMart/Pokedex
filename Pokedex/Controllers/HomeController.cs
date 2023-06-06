using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonServices _pokemonServices;
        private getColors color;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
            color = new();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.color = this.color;
            return View(await _pokemonServices.GetAllPokemons());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}