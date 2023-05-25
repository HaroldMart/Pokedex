using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace Pokedex.Controllers
{
    public class TypePokemonsController : Controller
    {
        private readonly TypePokemonServices _typePokemonServices;
        public TypePokemonsController(ApplicationContext dbContext)
        {
            _typePokemonServices = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _typePokemonServices.GetAllTypePokemons());
        }
    }
}
