CREATE TABLE [myst].[Client] (
    [ClientId] INT           NOT NULL,
    [UserName] NVARCHAR (64) NOT NULL,
    [FirstName] NVARCHAR(64) NULL, 
    [LastName] NVARCHAR(64) NOT NULL, 
    [Password] NVARCHAR(512) NULL, 
    [Email] NVARCHAR(256) NOT NULL, 
    [Version] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [UpdatedDate] DATETIME NOT NULL
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([ClientId] ASC)
);

