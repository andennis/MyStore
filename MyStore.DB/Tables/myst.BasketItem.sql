CREATE TABLE [myst].[BasketItem]
(
	[BasketItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientId] INT NOT NULL, 
    [ProductId] INT NOT NULL,
    [Version] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [UpdatedDate] DATETIME NOT NULL
    CONSTRAINT [FK_BasketItem_Client] FOREIGN KEY ([ClientId]) REFERENCES [myst].[Client]([ClientId]), 
    CONSTRAINT [FK_BasketItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [myst].[Product]([ProductId])
)
