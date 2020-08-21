CREATE TABLE [dbo].[AuthorizedActions]
(
	[Id] INT NOT NULL, 
	AuthorizedActionName nvarchar(300) NOT NULL,

    CONSTRAINT [PK_AuthorizedActions] PRIMARY KEY ([Id]) 
)
