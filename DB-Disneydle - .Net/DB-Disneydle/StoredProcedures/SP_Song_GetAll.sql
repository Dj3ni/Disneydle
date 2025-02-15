CREATE PROCEDURE [dbo].[SP_Song_GetAll]

AS
Begin
	Select 
		[Title],
		[Content],
		[Clip]

		From [Song]
End
