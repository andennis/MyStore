--Add user Admin 
IF NOT EXISTS(SELECT * FROM myst.[User] WHERE UserName = 'admin')
INSERT INTO myst.[User] ( UserName, [Password], [Version], CreatedDate, UpdatedDate)
VALUES  ('admin', 'admin', 1, GETDATE(), GETDATE())
GO
