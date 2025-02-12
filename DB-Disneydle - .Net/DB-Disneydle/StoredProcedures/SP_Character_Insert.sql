CREATE PROCEDURE [dbo].[SP_Character_Insert]
	@name Nvarchar(150),
	@clothingColor Nvarchar(150),
	@role Nvarchar(50),
	@parutionYear smallInt,
	@gender varchar(50),
	@hairColor varchar(100),
	@type varchar(100),
	@continent varchar(20)

AS
BEGIN
	Insert Into [Character]([Name], [ClothingColor],[Role],[ParutionYear],[Gender],[HairColor],[Type],[Continent])
		Output [Inserted].[Character_Id]
		Values
			(@name, @clothingColor, @role, @parutionYear,@gender,@hairColor,@type,@continent)
END