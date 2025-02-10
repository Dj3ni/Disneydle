CREATE TABLE [dbo].[Character]
(
	[Character_Id] INT Identity(1,1) PRIMARY KEY,
	[Name] NVarchar(150) NOT NULL,
	[ClothingColor] Nvarchar(150) NOT NULL,
	[Role] Nvarchar(50) NOT NULL Check ([Role] in ('Protagonist','Sidekick', 'Companion','Antagonist')),
	[ParutionYear] SmallInt NOT NULL Check ([ParutionYear] Between 1900 and 2100),
	[Gender] Nvarchar(50) NOt null Check ([Gender] in ('Male','Female','Other')),
	[HairColor] Nvarchar(100) Not null Default 'none',
	[Type] Nvarchar(100) Not null,
	[Continent] Nvarchar(20) Not null Check ([Continent] in ('Asia','Africa','Europe','Océania','North America','South America'))

	
)
