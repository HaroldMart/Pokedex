using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Region Region { get; set; }
        public TypePokemon Type1 { get; set; }
        public TypePokemon? Type2 { get; set; }
        public string ColorType1 { get; set; }
        public string ColorType2 { get; set;}

    }
}
