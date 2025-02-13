CREATE PROCEDURE [dbo].[SP_Character_Delete]
	@character_Id int
AS
Begin
	DELETE 
		FROM [Character]
		Where [Character_Id] = @character_Id
End
