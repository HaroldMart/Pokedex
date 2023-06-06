using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonServices _pokemonServices;
        private readonly RegionServices _regionServices;

        public HomeController(ApplicationContext dbContext)
        {
            _pokemonServices = new(dbContext);
            _regionServices = new(dbContext);
        }

        public async Task<IActionResult> Index(FilterPokemonViewModel fpvm)
        {
            ViewBag.Regions = await _regionServices.GetAllRegions();
            return View(await _pokemonServices.GetAllViewModelWithFilters(fpvm));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Search(string name)
        {
            ViewBag.Regions = await _regionServices.GetAllRegions();
            return View("Index", await _pokemonServices.GetAllViewModelWithSearch(name));
        }
    }
}