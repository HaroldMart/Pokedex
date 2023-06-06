using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class getColors
    {
        public List<string> colors = new List<string>()
        {
                "Rojo",
                "Verde",
                "Amarillo",
                "Azul",
                "Marron",
                "Rosado",
                "Gris",
                "Morado"
        }; 
        
        public List<string> AllColorsTypePokemon()
        {
            return colors;
        }

        public string ChangeColorType(string color)
        {
            switch (color)
            {
                case "Rojo":
                    return "#c00021";
                case "Verde":
                    return "green";
                case "Amarillo":
                    return "#ffba08";
                case "Azul":
                    return "blue";
                case "Marron":
                    return "#6f1d1b";
                case "Rosado":
                    return "pink";
                case "Gris":
                    return "gray";
                case "Morado":
                    return "purple";
            };
            return "black";
        }
    }
}
