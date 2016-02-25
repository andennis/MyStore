CREATE TABLE [myst].[Client] (
    [ClientId] INT           NOT NULL IDENTITY,
    [FirstName] NVARCHAR(64) NULL, 
    [LastName] NVARCHAR(64) NOT NULL, 
    [Email] NVARCHAR(256) NOT NULL, 
	[UserId] INT NULL,
    [Version] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [UpdatedDate] DATETIME NOT NULL
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([ClientId] ASC), 
);

