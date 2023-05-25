let typePokemon1 = document.getElementById("typePokemon1");
let typePokemon1 = document.getElementById("typePokemon2");

function changeColorPokemon(Color) {
    switch (Color) {
        case "Tierra": Color.style.color = "#116D6E";
            break;
        case "Fuego": Color.style.color = "#CD1818";
            break;
        default: Color.style.color = "#E55807"
    }
}

changeColor(typePokemon1.value);
changeColor(typePokemon2.value);

typePokemon1.style.color = "#E55807";