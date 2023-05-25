using Application.Repository;
using Application.ViewModels;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegionServices
    {
        private readonly RegionRepository regionRepository;
        public RegionServices(ApplicationContext dbContext)
        {
            regionRepository = new(dbContext);
        }

        public async Task<List<RegionViewModel>> GetAllRegions()
        {
            var RegionList = await regionRepository.GetAllAsync();

            return RegionList.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name,
                Pokemons = region.Pokemons
            }).ToList();
        }
    }
}
