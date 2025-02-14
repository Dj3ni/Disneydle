CREATE PROCEDURE [dbo].[SP_Quote_Update]
	@quote_id int,
	@language varchar(64),
	@content varchar(Max),
	@clip varchar(Max),
	@character_id int
AS
Begin
	Update [Quote]
		Set [Language] = @language,
			[Content] = @content,
			[Clip] = @clip,
			[Character_Id] = @character_id

		Where [Quote_Id] = @quote_id
End
