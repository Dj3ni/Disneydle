CREATE PROCEDURE [dbo].[SP_Song_Delete]
	@song_id int
AS
Begin
	Delete
		From [Song]
			Where [Song_Id] = @song_id
End
