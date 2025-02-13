CREATE PROCEDURE [dbo].[SP_Character_GetById]
	@Character_Id int

AS
Begin
	SELECT	[Character_Id],
			[Name],
			[ClothingColor],
			[Role],
			[ParutionYear],
			[Gender],
			[HairColor],
			[Type],
			[Continent]
			
		FROM [Character] 
	Where [Character_Id] = @Character_ID
End
