CREATE TABLE [dbo].[SongCharacter]
(
	[Song_Id] INT NOT NULL,
	[Character_Id] Int Not null,
	Constraint [PK_Song_Character] Primary key (Song_Id,Character_Id),/* We combine both so it will never be possible to encode twice the same singer for the same song */
	Constraint [FK_Song] Foreign key (Song_Id) References [Song](Song_Id) On Delete Cascade,
	Constraint [FK_Singer] Foreign key (Character_Id) References [Character](Character_Id) On delete Cascade
)
