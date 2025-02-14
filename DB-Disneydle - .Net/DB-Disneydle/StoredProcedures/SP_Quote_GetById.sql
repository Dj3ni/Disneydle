CREATE PROCEDURE [dbo].[SP_Quote_GetById]
	@quote_id int
AS
Begin
	SELECT 
		[Quote_Id],
		[Language],
		[Content],
		[Character_Id]
		[Clip]

	From [Quote]
		Where [Quote_Id] = @quote_id
End
