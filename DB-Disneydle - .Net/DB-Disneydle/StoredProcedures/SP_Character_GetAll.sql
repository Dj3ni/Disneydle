CREATE PROCEDURE [dbo].[SP_Character_GetAll]
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
END
