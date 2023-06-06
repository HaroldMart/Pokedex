using Application.Services;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SavePokemonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe agregar un nombre al pokemon")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe agregar una imagen al pokemon")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Debe agregar una region al pokemon")]
        public int Id_region { get; set; }

        [Required(ErrorMessage = "Debe agregar un tipo primario al pokemon")]
        public int IdType1 { get; set; }
        public int? IdType2 { get; set; }
        //public List<RegionViewModel> RegionList { get; set; }
        //public List<TypePokemonViewModel> typePokemonList { get; set; }

    }
}
