using Application.Services;
using Application.ViewModels;
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

        public async Task<IActionResult> Save()
        {
            return View("SaveRegion", new RegionViewModel()); ;
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegion(RegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _regionServices.Add(vm);
            return RedirectToRoute(new { Controller = "Regions", Action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionServices.GetByIdRegionViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveRegion", vm);
            }
            await _regionServices.Update(vm);
            return RedirectToRoute(new { Controller = "Regions", Action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionServices.GetByIdRegionViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionServices.Delete(id);
            return RedirectToRoute(new { Controller = "Regions", Action = "Index" });
        }
    }
}
