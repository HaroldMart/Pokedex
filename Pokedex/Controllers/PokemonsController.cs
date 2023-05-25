using Application.Services;
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
    }
}
