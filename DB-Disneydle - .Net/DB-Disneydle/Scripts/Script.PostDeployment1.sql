/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/* Variables pour les tables*/

Declare @CharacterJson NVARCHAR(Max)

Set @CharacterJson ='[
    {
    "name": "Mickey Mouse",
    "clothingColor": "Red",
    "role": "Protagonist",
    "parutionYear": 1928,
    "gender": "Male",
    "hairColor": "None",
    "type":"Mouse",
    "continent": "North America"
    },
    {
    "name": "Donald Duck",
    "clothingColor": "Blue",
    "role": "Sidekick",
    "parutionYear": 1934,
    "gender": "Male",
    "hairColor": "White",
    "type": "Bird",
    "continent": "North America"
    },
    {
    "name": "Cinderella",
    "clothingColor": "Blue",
    "role": "Protagonist",
    "parutionYear": 1950,
    "gender": "Female",
    "hairColor": "Blonde",
    "type": "Human",
    "continent": "Europe"
    },
    {
    "name": "Maleficent",
    "clothingColor": "Black and Purple",
    "role": "Antagonist",
    "parutionYear": 1959,
    "gender": "Female",
    "hairColor": "Black",
    "type": "Dark Fairy",
    "continent": "Europe"
    },
    {
    "name": "Mulan",
    "clothingColor": "Green and Blue",
    "role": "Protagonist",
    "parutionYear": 1998,
    "gender": "Female",
    "hairColor": "Black",
    "type": "Human",
    "continent": "Asia"
    },
    {
    "name": "Simba",
    "clothingColor": "Golden",
    "role": "Protagonist",
    "parutionYear": 1994,
    "gender": "Male",
    "hairColor": "Golden",
    "type": "Lion",
    "continent": "Africa"
    }]'

	/* Insert into Table Character */
