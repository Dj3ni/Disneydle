CREATE PROCEDURE [dbo].[SP_Quote_Insert]
	@language varchar (64),
	@content varchar(max),
	@clip varchar(max),
	@character_id int
AS

Begin
	Insert into [Quote]
			([Language],
			[Content],
			[Clip],
			[Character_Id])

		Output [inserted].[Quote_Id]

		Values
			(@language,
			@content,
			@clip,
			@character_id)
End
