namespace Pokedex.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name {  get; set; }

        //Navegation property
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
