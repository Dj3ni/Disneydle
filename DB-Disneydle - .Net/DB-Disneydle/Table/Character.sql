CREATE TABLE [dbo].[Character]
(
	[Character_Id] INT Identity Constraint[PK_Character] PRIMARY KEY,
	[Name] Nvarchar(150) NOT NULL,
	[ClothingColor] Nvarchar(150) NOT NULL,
	[Role] Nvarchar(50) NOT NULL, 
	--Check ([Role] in ('Protagonist','Sidekick', 'Companion','Antagonist')),
	[ParutionYear] SmallInt NOT NULL Constraint [CK_Character_Parution] Check ([ParutionYear] Between 1900 and 2100),
	[Gender] Nvarchar(50) Not null Constraint [CK_Character_Gender] Check ([Gender] in ('Male','Female','Other')),
	[HairColor] Nvarchar(100) Not null Default 'None',
	[Type] Nvarchar(100) Not null,
	[Continent] Nvarchar(20) Not null Constraint [CK_Character_Continent] Check ([Continent] in ('Asia','Africa','Europe','Océania','North America','South America')),

	
)
