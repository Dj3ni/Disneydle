CREATE PROCEDURE [dbo].[SP_Song_Update]
	@song_id int,
	@title varchar (100),
	@content varbinary(max) null,
	@clip nvarchar(max) null
AS
Begin
	Update [Song]
		Set [Title] = @title,	
			[Content] = @content,
			[Clip] = @clip

		Where [Song_Id] = @song_id
End
