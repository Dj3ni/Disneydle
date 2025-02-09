let url = "https://api.disneyapi.dev/character";
// let page2 = "https://api.disneyapi.dev/character?page=2";
let page = "https://api.disneyapi.dev/character?page=";

// const axios = require("axios");
const charactersArray = [];
const numberOfPages = 10;
const Result_Div = document.getElementById("result");
// console.log(Result_Div);

async function getCharacter() {
    try {
        // On parcourt i pages de l'api pour chercher les infos
        for(i = 1; i<=numberOfPages;i++){
            const response = await axios.get(`${page}${i}`);
        // console.log(response.data.data);
        // All the characters:
        const characters = response.data.data

        characters.forEach(character => {
            // console.log(character.name);
            // console.log(character.imageUrl);

            // Créer un objet avec les données du personnage
            const characterData = {
                name: character.name,
                image: character.imageUrl
            };
            // Ajouter cet objet au tableau
            charactersArray.push(characterData);
        });
        }
        
    } catch (error) {
        console.error("Erreur lors de la récupération des données :", error.message);
    }
}

// Insérer les infos dans le html après requête API
getCharacter().then(()=>{
    charactersArray.forEach(character=>{
        const name = document.createElement("h4");
        const imgElement = document.createElement("img");
        name.innerText = character.name;
        imgElement.src = character.image;
        imgElement.alt = character.name;
        Result_Div.appendChild(name);
        Result_Div.appendChild(imgElement);
    })
});




// async function run() {
//     await getCharacter(); // On attend que la récupération soit terminée
//     // console.log(charactersArray); // Maintenant les données sont disponibles
//     // console.log(charactersArray[0]); // Accéder au premier élément
// // const Name_DIV = document.getElementById("name");
// // console.log(Name_DIV);
// // const IMAGE_DIV = document.getElementById("picture");

// charactersArray.forEach(character=>{
//     const name = document.createElement("h4");
//     const image = document.createElement("img");
//     name.innerText = character.name;
//     image.classList.add
//     Result_Div.appendChild(name);
//     // Name_DIV.innerHTML = character.name;
//     // IMAGE_DIV.innerHTML = character.image;
// })
// }

// run();



// axios.get(url)
//             .then((response)=>{
//                 console.log(response.data);
// })