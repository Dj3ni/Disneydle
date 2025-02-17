CREATE PROCEDURE [dbo].[SP_CharacterSong_AddSinger]
	@character_id int,
	@song_id int
AS
Begin
	Insert into [SongCharacter]
		([Character_Id],[Song_Id])
		Values
		(@character_id,@song_id)
End
