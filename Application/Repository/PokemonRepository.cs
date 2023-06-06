using Application.ViewModels;
using Database;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class PokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContext.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();  
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {
            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbContext.Set<Pokemon>().Include(r => r.Region).Include(t1 => t1.Type1).Include(t2 => t2.Type2).ToListAsync();
        }
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Pokemon>().FindAsync(id);
        }
    }
}
