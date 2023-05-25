CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UserName] varchar(100) not null,
	[HashedPassword] varchar(max) not null
)
