CREATE TABLE [myst].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY,
	[UserName] NVARCHAR (64) NOT NULL,
	[Password] NVARCHAR(512) NULL, 
    [Version] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    [UpdatedDate] DATETIME NOT NULL
)
