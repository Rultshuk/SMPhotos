CREATE TABLE [smp].[Image]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(64) NULL,
	[AlbumId] INT NOT NULL,
	CONSTRAINT [FK_ImageAlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [smp].[Album]([Id])
)
