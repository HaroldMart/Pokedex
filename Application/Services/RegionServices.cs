using Application.Repository;
using Application.ViewModels;
using Database;
using Pokedex.Models;
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
            }).ToList();
        }

        public async Task Add(RegionViewModel vm)
        {
            Region region = new()
            {
                Name = vm.Name,
            };

            await regionRepository.AddAsync(region);
        }

        public async Task Update(RegionViewModel vm)
        {
            Region region = await regionRepository.GetByIdAsync(vm.Id);
            region.Name = vm.Name;

            await regionRepository.UpdateAsync(region);
        }

        public async Task Delete(int id)
        {
            Region region = await regionRepository.GetByIdAsync(id);
            await regionRepository.DeleteAsync(region);
        }

        public async Task<RegionViewModel> GetByIdRegionViewModel(int id)
        {
            var region = await regionRepository.GetByIdAsync(id);
            RegionViewModel vm = new()
            {
                Id = region.Id,
                Name = region.Name,
            };
            return vm;
        }
    }
}
