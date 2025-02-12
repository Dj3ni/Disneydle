CREATE TABLE [dbo].[Song]
(
	[Song_Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[Title] Nvarchar(100) NOT NULL,
	[Content] Varbinary(MAX), -- Mp3 File
	[Clip] NVarchar(Max) -- link for video
)
