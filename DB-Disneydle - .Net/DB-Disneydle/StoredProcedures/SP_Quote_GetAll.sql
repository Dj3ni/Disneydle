CREATE PROCEDURE [dbo].[SP_Quote_GetAll]

AS
Begin
	SELECT 
			[Quote_Id],
			[Language],
			[Content],
			[Character_Id],
			[Clip]

		From [Quote]
End
