use [DB-Disneydle]
go

-- Testing: 
--select * from Quote
--select * from Character

-- Select all infos from character 1 + his citations
select  * from Character 
			Join Quote 
				on [Quote].[Character_Id] = [Character].[Character_Id]
				where Character.Character_Id =1

Exec SP_Quote_GetById @quote_id = 1;


-- select all songs from character 5
SELECT 
        c.Character_Id AS CharacterId,
        c.Name AS CharacterName,
        s.Song_Id AS SongId,
        s.Title AS SongTitle
    FROM Character c
    LEFT JOIN SongCharacter cs ON c.Character_Id = cs.Character_Id
    LEFT JOIN Song s ON cs.Song_Id = s.Song_Id
    WHERE c.Character_Id = 5;

-- Select all the singers of the song 2

Select 
		s.Song_Id as SongId,
		s.Title,
		c.Character_Id,
		c.Name

	From Song s
	Left Join SongCharacter sc On s.Song_Id = sc.Song_Id
	Left Join Character c On sc.Character_Id = c.Character_Id
	Where s.Song_Id = 2