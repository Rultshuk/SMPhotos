CREATE TABLE [smp].[Image]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(64) NULL,
	[AlbumId] INT NOT NULL,
	CONSTRAINT [PK_ImageId] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_ImageAlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [smp].[Album]([Id])
)
