CREATE TABLE [myst].[OrderItem]
(
	[OrderItemId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Amount] INT NOT NULL, 
    [Comment] NVARCHAR(MAX) NULL,
    [Version] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [UpdatedDate] DATETIME NOT NULL
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderId]) REFERENCES [myst].[Order]([OrderId]), 
    CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [myst].[Product]([ProductId])
)
