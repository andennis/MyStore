﻿CREATE TABLE [myst].[Product]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(64) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Price] MONEY NULL,
    [Version] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [UpdatedDate] DATETIME NOT NULL 
)
GO

CREATE UNIQUE INDEX [IX_Product_Name] ON [myst].[Product] ([Name])
