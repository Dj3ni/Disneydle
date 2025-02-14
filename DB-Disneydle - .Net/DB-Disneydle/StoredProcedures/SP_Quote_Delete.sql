CREATE PROCEDURE [dbo].[SP_Quote_Delete]
	@quote_id int
AS
Begin
	Delete 
		From [Quote]
			Where [Quote_Id] = @quote_id
End
