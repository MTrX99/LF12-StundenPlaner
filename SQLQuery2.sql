CREATE TABLE [dbo].[Schüler] (
    [id]       INT           IDENTITY (0, 1) primary key,
    [Name]     VARCHAR (MAX) NOT NULL,
    [KlasseID] INT           NULL,
    FOREIGN KEY ([KlasseID]) REFERENCES [dbo].[Klasse] ([id])
);

drop table Schüler