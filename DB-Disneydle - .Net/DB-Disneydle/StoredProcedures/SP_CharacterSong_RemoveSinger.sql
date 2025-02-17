CREATE PROCEDURE [dbo].[SP_CharacterSong_RemoveSinger]
	@character_id int,
	@song_id int
AS
Begin
	Delete from [SongCharacter]
			Where
				[Character_Id] = @character_id
				AND [Song_Id] = @song_id		
End

