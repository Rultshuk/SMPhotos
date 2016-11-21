﻿CREATE TABLE [smp].[Album]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(64),
	[Path] NVARCHAR(128) NOT NULL,
	[Guid] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_AlbumId] PRIMARY KEY ([Id])
)
