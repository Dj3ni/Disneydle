const Result_Div = document.getElementById("result");
let url = "https://api.lorcana-api.com/cards/all"

const cardsArray = [];

async function getCards() {

    try {

        const response = await axios.get(url);
        console.log(response.data);
        // All the cards
        const cards = response.data;

        cards.forEach(card => {
            // console.log(card.Name);
            // console.log(card.Image);
            // we split the card name so we can get the name of character and the title
                let trimmedString = card.Name.trim();
                let nameBeforeDash = trimmedString;
                let nameAfterDash = trimmedString;
                //sometimes it doens't have the dash
                if (trimmedString.includes(" - ")) {
                    // Diviser la chaîne à la première occurrence du tiret
                    nameBeforeDash = trimmedString.split(" - ")[0];
                    nameAfterDash = trimmedString.split(" - ")[1];
                }
                console.log(nameBeforeDash);
            // Créer un objet avec les données de la carte
                const cardData = {
                    name: nameBeforeDash,
                    image: card.Image,
                    title: nameAfterDash
                };
            // Ajouter cet objet au tableau
            cardsArray.push(cardData);
        });
        
    } catch (error) {
        console.error("Erreur lors de la récupération des données :", error.message);
    }
}

getCards();

// Insérer les infos dans le html après requête API
getCards().then(()=>{
    cardsArray.forEach(card=>{
        // Character Name
        const name = document.createElement("h4");
        name.innerText = card.name;
        // Card Title
        const title = document.createElement("h5");
        title.innerHTML = card.title;
        // Card Image
        const imgElement = document.createElement("img");
        imgElement.src = card.image;
        imgElement.alt = card.name;
        imgElement.style.width="200px";

        //Insert in Html
        Result_Div.appendChild(name);
        Result_Div.appendChild(title);
        Result_Div.appendChild(imgElement);
    })
});