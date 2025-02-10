CREATE TABLE [dbo].[SongCharacter]
(
	[Song_Id] INT NOT NULL,
	[Character_Id] Int Not null,
	Primary key (Song_Id,Character_Id),/* Pour éviter qu'un perso soit plusieurs fois associé à la même chanson, on combine les 2 */
	Foreign key (Song_Id) References [Song](Song_Id) On Delete Cascade,
	Foreign key (Character_Id) References [Character](Character_Id) On delete Cascade
)
