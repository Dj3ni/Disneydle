CREATE PROCEDURE [dbo].[SP_Song_GetByCharacterId]
		@character_id int
AS
Begin
	SELECT -- all the columns we wante to display
			c.Character_Id,
			c.Name,
			s.Song_Id,
			s.Title,
			s.Content,
			s.Clip
		FROM Character c -- from Character Column, join with the others
		LEFT JOIN SongCharacter cs ON c.Character_Id = cs.Character_Id
		LEFT JOIN Song s ON cs.Song_Id = s.Song_Id
		WHERE c.Character_Id = @character_id; -- We want only this character song

End