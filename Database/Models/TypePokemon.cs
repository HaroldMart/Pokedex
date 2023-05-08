namespace Pokedex.Models
{
    public class TypePokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navegation property
        public ICollection<Pokemon> Pokemons { get; set; }

    }
}
