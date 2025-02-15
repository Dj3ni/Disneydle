CREATE PROCEDURE [dbo].[SP_Song_GetAllSingers]
	@song_id int
AS
Begin
	Select 
			s.Song_Id as SongId,
			s.Title,
			c.Character_Id,
			c.Name

		From Song s
			Left Join SongCharacter sc On s.Song_Id = sc.Song_Id
			Left Join Character c On sc.Character_Id = c.Character_Id
		Where s.Song_Id = @song_id
End
