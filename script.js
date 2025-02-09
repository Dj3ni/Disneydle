let url = "https://api.disneyapi.dev/character";

const axios = require("axios");
const characters = [];
const numberOfCharacters = 10;

async function getCharacter() {
    try {
        const response = await axios.get(url);
        console.log(response.data);
    } catch (error) {
        console.error("Erreur lors de la récupération des données :", error.message);
    }
}

getCharacter();

getCharacter();

// axios.get(url)
//             .then((response)=>{
//                 console.log(response.data);
// })