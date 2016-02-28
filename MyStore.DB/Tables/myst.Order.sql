CREATE TABLE [myst].[Order]
(
	[OrderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderRefNumber] NVARCHAR(64) NULL, 
	[Status] INT NOT NULL DEFAULT 1,
    [Comment] NVARCHAR(MAX) NULL, 
    [ClientId] INT NOT NULL, 
    [Version] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [UpdatedDate] DATETIME NOT NULL
    CONSTRAINT [FK_Order_Client] FOREIGN KEY ([ClientId]) REFERENCES [myst].[Client]([ClientId]) 
)
