CREATE PROCEDURE [dbo].[SP_Song_GetAll]

AS
Begin
	Select 
		[Song_Id],
		[Title],
		[Content],
		[Clip]

		From [Song]
End
