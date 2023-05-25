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
    public class TypePokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public TypePokemonRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TypePokemon typePokemon)
        {
            await _dbContext.AddAsync(typePokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TypePokemon typePokemon)
        {
            _dbContext.Entry(typePokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TypePokemon typePokemon)
        {
            _dbContext.Set<TypePokemon>().Remove(typePokemon);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TypePokemon>> GetAllAsync()
        {
            return await _dbContext.Set<TypePokemon>().ToListAsync();
        }
        public async Task<TypePokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TypePokemon>().FindAsync(id);
        }
    }

}

