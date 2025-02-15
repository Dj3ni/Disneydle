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

--	-- Déclaration de la table variable pour stocker les IDs insérés
DECLARE @InsertedCharacterIds TABLE (Character_Id int);
Declare @InsertedQuoteIds Table (Quote_Id int)
Declare @InsertedSongIds table (Song_Id int)

/* Insert 5 Charcters into Table Character */

---- Pumbaa
Insert into @insertedcharacterids(character_id)
exec sp_character_insert 
@name ='Pumbaa', 
@clothingcolor = 'Brown', 
@role= 'Sidekick',
@parutionyear = 1994,
@gender ='Male',
@haircolor = 'Black',
@type = 'Warthog',
@continent='Africa'
	/* on va chercher l'id attribué par la table*/
declare @char7id int;
select @char7id = character_id from @insertedcharacterids

---- Rafiki
Insert into @insertedcharacterids(character_id)
exec sp_character_insert 
@name ='Rafiki', 
@clothingcolor = 'Grey and Blue', 
@role= 'Mentor',
@parutionyear = 1994,
@gender ='Male',
@haircolor = 'Gray',
@type = 'Mandrill',
@continent='Africa'
Declare @Char6Id int;
Select @Char6Id = Character_Id From @InsertedCharacterIds

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

/* Insertion de citations */

--- Hakuna Matata
Insert into @InsertedQuoteIds(Quote_Id)
Exec SP_Quote_Insert
@language ='Fr',
@content = 'Hakuna Matata ! Ça veut dire pas de souci!',
@character_id = 1,
@clip = null

declare @quote1id int
select @quote1id = Quote_Id from @InsertedQuoteIds

--- Mr Porc
Insert into @InsertedQuoteIds(Quote_Id)
Exec SP_Quote_Insert
@language ='Fr',
@content = 'C''est à moi que tu parles ? C''est à moi que tu parles ? On m''appelle MONSIEUR porc',
@character_id = 1,
@clip = null

declare @quote2id int
select @quote2id = Quote_Id from @InsertedQuoteIds

--- Il vit en toi
Insert into @InsertedQuoteIds(Quote_Id)
Exec SP_Quote_Insert
@language ='Fr',
@content = 'Regarde au-delà de ce que tu vois',
@character_id = 2,
@clip = null

declare @quote3id int
select @quote3id = Quote_Id from @InsertedQuoteIds

--- Le passé est douloureux
Insert into @InsertedQuoteIds(Quote_Id)
Exec SP_Quote_Insert
@language ='Fr',
@content = 'Eh oui, le passé est douloureux, mais à mon sens, on peut soit le fuir, soit tout en apprendre.',
@character_id = 2,
@clip = null

declare @quote4id int
select @quote4id = Quote_Id from @InsertedQuoteIds

/* Insert songs */

--- You'll be in my heart
Insert into @InsertedSongIds(Song_Id)
Exec SP_Song_Insert
@title = 'You''ll Be in My Heart',
@content=1234,
@clip='https://www.youtube.com/watch?v=Mx1MmY1Bb50'

declare @song1Id int
select @song1Id = Song_Id from @InsertedSongIds

--- Reflection
Insert into @InsertedSongIds(Song_Id)
Exec SP_Song_Insert
@title = 'Reflection',
@content= 5678,
@clip='https://www.youtube.com/watch?v=Y3vXJsk0Vhk'

declare @song2Id int
select @song2Id = Song_Id from @InsertedSongIds
/* we link it to Character */
Insert into SongCharacter (Character_Id,Song_Id)
	Values(5, @song2Id)
