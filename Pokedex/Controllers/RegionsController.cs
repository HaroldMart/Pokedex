using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Pokedex.Controllers
{
    public class RegionsController : Controller
    {

        private readonly RegionServices _regionServices;

        public RegionsController(ApplicationContext dbContext)
        {
            _regionServices = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _regionServices.GetAllRegions());
        }
    }
}
