CREATE TABLE [dbo].[Quote]
(
	[Quote_Id] INT NOT NULL Constraint [PK_Quote_Id] PRIMARY KEY Identity,
	[Language] NVARCHAR(64) NOT NULL Constraint [CK_Language] Check ([Language] in ('French','English')),
	[Content] Nvarchar(Max) Not Null Constraint [CK_MinLength]Check (Len([Content])>=2),
	[Character_Id] Int Constraint [FK_Character] References [Character]([Character_Id]),
	[Clip] Nvarchar(MAX),    

)
