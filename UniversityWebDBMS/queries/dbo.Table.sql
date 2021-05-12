CREATE TABLE [dbo].LoginCredentials
(
	[id] VARCHAR(50) NOT NULL , 
    [username] VARCHAR(50) NOT NULL, 
    [role] VARCHAR(50) NOT NULL DEFAULT user, 
    [password] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([id])
)

