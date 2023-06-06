namespace Pokedex.Models
{
    public class TypePokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Color { get; set; }

        //Navegation property
        public ICollection<Pokemon> Pokemons1 { get; set; }
        public ICollection<Pokemon> Pokemons2 { get; set; }

    }
}
