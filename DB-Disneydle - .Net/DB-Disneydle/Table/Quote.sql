CREATE TABLE [dbo].[Quote]
(
	[Quote_Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[Content] Nvarchar(Max) Not Null Check (Len([Content])>=2),
	[Character_Id] Int References [Character]([Character_Id]),
	[Clip] Nvarchar(MAX)
)
