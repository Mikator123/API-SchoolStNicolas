CREATE TABLE [dbo].[Categories]
(
	[Id] INT Identity NOT NULL, 
    [CategoryName] NVARCHAR(50) UNIQUE NOT NULL, 
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id]) 
)
