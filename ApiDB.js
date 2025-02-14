const Result_Div = document.getElementById("result");
let urlGetAll = "https://localhost:7050/api/character";

// Doesn't work (cors prob): 
// fetch(urlGetAll)
//     .then(response =>{
//         if(!response.ok) throw new Error("Response not ok")
//         console.log(response);
//     })
//     .catch(error => console.error("Il y a eu un problème avec votre requête", error))

// Ok but Cors prob
async function getCharacters(){
    try{
        const response = await axios.get(urlGetAll)
        console.log(response.data);
    }
    catch (Error){
        console.error("Erreur lors de la récupération des données :", Error.message);
    }
}

getCharacters();

async function getCharacter(characterId){
    try{
        const response = await axios.get(`${urlGetAll}/${characterId}`)
        console.log(response.data);
    }
    catch(Error){
        console.error("Erreur lors de la récupération des données :", Error.message);
    }
}

// getCharacter(2);