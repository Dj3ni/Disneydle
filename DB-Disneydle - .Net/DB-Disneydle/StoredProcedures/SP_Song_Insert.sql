CREATE PROCEDURE [dbo].[SP_Song_Insert]
	@title nvarchar(100),
	@content varbinary(Max) null,
	@clip nvarchar(max) null
AS
Begin
	Insert into [Song]
		([Title],
		[Content],
		[Clip])

		Output [inserted].[Song_Id]

		Values
			(@title, @content,@clip)

End