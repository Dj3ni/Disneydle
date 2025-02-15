CREATE PROCEDURE [dbo].[SP_Song_Insert]
	@title nvarchar(100),
	@content varbinary(Max),
	@clip nvarchar(max)
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