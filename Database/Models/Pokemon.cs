namespace Pokedex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Id_region { get; set; }
        public int IdType1 { get; set; }
        public int IdType2 { get; set; }

        //Navegation property
        public Region Region { get; set; }
        public TypePokemon Type1 { get; set; }
        public TypePokemon Type2 { get; set; }

    }
}
