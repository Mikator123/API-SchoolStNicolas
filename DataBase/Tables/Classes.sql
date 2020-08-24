CREATE TABLE [dbo].[Classes]
(
	[Id] INT Identity NOT NULL, 
    [ClassName] NVARCHAR(50) UNIQUE NOT NULL, 
    [ClassInfos] NVARCHAR(MAX) NULL, 

    CONSTRAINT [PK_Classes] PRIMARY KEY ([Id]), 
)

