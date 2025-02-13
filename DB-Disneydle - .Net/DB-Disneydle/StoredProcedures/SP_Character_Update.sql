CREATE PROCEDURE [dbo].[SP_Character_Update]
	@character_Id int,
	@name Nvarchar(150),
	@clothingColor Nvarchar(150),
	@role Nvarchar(50),
	@parutionYear smallInt,
	@gender varchar(50),
	@hairColor varchar(100),
	@type varchar(100),
	@continent varchar(20)
AS
Begin
	UPDATE [Character]
		Set [Name] = @name,
			[ClothingColor] = @clothingColor,
			[Role] = @role,
			[ParutionYear] = @parutionYear,
			[Gender] = @gender,
			[HairColor] = @hairColor,
			[Type] = @type,
			[Continent] = @continent
		Where
			[Character_Id] = @character_Id
End
