CREATE PROCEDURE [dbo].[SP_Song_GetById]
	@song_id int

As

Begin
	Select
		[Title],
		[Content],
		[Clip]

		From [Song]
			Where [Song_Id] = @song_id
End
