using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TypePokemonViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Pokemon> Pokemons1 { get; set; }
        public ICollection<Pokemon> Pokemons2 { get; set; }
    }
}
