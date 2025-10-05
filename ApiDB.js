const Result_Div = document.getElementById("result");
let urlGetAll = "https://localhost:7050/api/Character";
const charactersArray = [];
const numberOfPages = 10;

// Ok but Cors prob (home only)
async function getCharacters(){
    try{
        const response = await axios.get(urlGetAll)
        // console.log(response.data)
        charactersArray.push(...response.data)
        displayCharacters()
    }
    catch (Error){
        console.error("Erreur lors de la récupération des données :", Error.message);
    }
}

getCharacters();

function displayCharacters(){
    Result_Div.innerHTML = "";
    charactersArray.forEach(character=>{
        const name = document.createElement("h4");
        const imgElement = document.createElement("img");

        name.innerText = character.name;
        imgElement.src = character.image;
        imgElement.alt = character.name;

        Result_Div.appendChild(name);
        Result_Div.appendChild(imgElement);
    })
}

async function getCharacter(characterId){
    try{
        const response = await axios.get(`${urlGetAll}/${characterId}`)
        console.log(response.data);
    }
    catch(Error){
        console.error("Erreur lors de la récupération des données :", Error.message);
    }
}

getCharacter(2);