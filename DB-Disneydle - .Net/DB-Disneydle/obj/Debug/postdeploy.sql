--/*
--Modèle de script de post-déploiement							
----------------------------------------------------------------------------------------
-- Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
-- Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
-- Exemple :      :r .\monfichier.sql								
-- Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
-- Exemple :      :setvar TableName MyTable							
--               SELECT * FROM [$(TableName)]					
----------------------------------------------------------------------------------------
--*/
--/* Variables pour les tables*/

--Declare @CharacterJson NVARCHAR(Max)

--Set @CharacterJson ='[
--    {
--    "name": "Mickey Mouse",
--    "clothingColor": "Red",
--    "role": "Protagonist",
--    "parutionYear": 1928,
--    "gender": "Male",
--    "hairColor": "None",
--    "type":"Mouse",
--    "continent": "North America"
--    },
--    {
--    "name": "Donald Duck",
--    "clothingColor": "Blue",
--    "role": "Sidekick",
--    "parutionYear": 1934,
--    "gender": "Male",
--    "hairColor": "White",
--    "type": "Bird",
--    "continent": "North America"
--    },
--    {
--    "name": "Cinderella",
--    "clothingColor": "Blue",
--    "role": "Protagonist",
--    "parutionYear": 1950,
--    "gender": "Female",
--    "hairColor": "Blonde",
--    "type": "Human",
--    "continent": "Europe"
--    },
--    {
--    "name": "Maleficent",
--    "clothingColor": "Black and Purple",
--    "role": "Antagonist",
--    "parutionYear": 1959,
--    "gender": "Female",
--    "hairColor": "Black",
--    "type": "Dark Fairy",
--    "continent": "Europe"
--    },
--    {
--    "name": "Mulan",
--    "clothingColor": "Green and Blue",
--    "role": "Protagonist",
--    "parutionYear": 1998,
--    "gender": "Female",
--    "hairColor": "Black",
--    "type": "Human",
--    "continent": "Asia"
--    },
--    {
--    "name": "Simba",
--    "clothingColor": "Golden",
--    "role": "Protagonist",
--    "parutionYear": 1994,
--    "gender": "Male",
--    "hairColor": "Golden",
--    "type": "Lion",
--    "continent": "Africa"
--    }]'

--	-- Déclaration de la table variable pour stocker les IDs insérés
DECLARE @InsertedCharacterIds TABLE (Character_Id int);
Declare @InsertedQuoteIds Table (Quote_Id int)

/* Insert 5 Charcters into Table Character */

-- Mickey
INSERT INTO @InsertedCharacterIds (Character_Id)
EXEC SP_Character_Insert 
    @name = 'Mickey Mouse', 
    @clothingColor = 'Red', 
    @role = 'Protagonist',
    @parutionYear = 1928,
    @gender = 'Male',
    @hairColor = 'None',
    @type = 'Mouse',
    @continent = 'North America';

DECLARE @Char1Id INT;
SELECT @Char1Id = Character_Id FROM @InsertedCharacterIds;

-- Donald
INSERT INTO @InsertedCharacterIds (Character_Id)
EXEC SP_Character_Insert 
    @name = 'Donald Duck', 
    @clothingColor = 'Blue', 
    @role = 'Sidekick',
    @parutionYear = 1934,
    @gender = 'Male',
    @hairColor = 'White',
    @type = 'Bird',
    @continent = 'North America';

DECLARE @Char2Id INT;
SELECT @Char2Id = Character_Id FROM @InsertedCharacterIds;

-- Mulan
Insert Into @InsertedCharacterIds(Character_Id)
Exec SP_Character_Insert 
	@name ='Mulan', 
	@clothingColor = 'Green and Blue', 
	@role= 'Protagonist',
	@parutionYear = 1998,
	@gender ='Female',
	@hairColor = 'Black',
	@type = 'Human',
	@continent='Asia'
	/* On va chercher l'id attribué par la table*/
Declare @Char3Id int;
Select @Char3Id = Character_Id From @InsertedCharacterIds

---- Cinderella
Insert Into @InsertedCharacterIds(Character_Id)
Exec SP_Character_Insert 
	@name ='Cinderella', 
	@clothingColor = 'Blue', 
	@role= 'Protagonist',
	@parutionYear = 1950,
	@gender ='Female',
	@hairColor = 'Blonde',
	@type = 'Human',
	@continent='Europe'
	/* On va chercher l'id attribué par la table*/
Declare @Char4Id int;
Select @Char4Id = Character_Id From @InsertedCharacterIds

---- Maleficent
Insert Into @InsertedCharacterIds(Character_Id)
Exec SP_Character_Insert 
	@name ='Maleficent', 
	@clothingColor = 'Black and Purple', 
	@role= 'Antagonist',
	@parutionYear = 1959,
	@gender ='Female',
	@hairColor = 'Black',
	@type = 'Dark Fairy',
	@continent='Europe'
	/* On va chercher l'id attribué par la table*/
Declare @Char5Id int;
Select @Char5Id = Character_Id From @InsertedCharacterIds

---- Pascal
Insert into @insertedcharacterids(character_id)
exec sp_character_insert 
@name ='Pascal', 
@clothingcolor = 'Green', 
@role= 'Companion',
@parutionyear = 2010,
@gender ='Male',
@haircolor = 'None',
@type = 'Chameleon',
@continent='Europe'
	/* on va chercher l'id attribué par la table*/
declare @char6id int;
select @char6id = character_id from @insertedcharacterids

--/* Insertion de citations */
GO
