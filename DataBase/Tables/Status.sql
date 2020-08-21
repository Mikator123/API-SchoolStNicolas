CREATE TABLE [dbo].[Status]
(
	[Id] INT IDENTITY NOT NULL,
	StatusName nvarchar(50) NOT NULL,

    CONSTRAINT [PK_Status] PRIMARY KEY ([Id]), 
)
