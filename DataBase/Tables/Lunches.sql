CREATE TABLE [dbo].[Lunches]
(
	[Id] INT Identity NOT NULL, 
    [LunchName] NVARCHAR(50) NOT NULL, 
    [LunchDescription] NVARCHAR(MAX) NULL, 
    [LunchDate] DATE NOT NULL, 
    [RemoveDate] DATE NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Lunches] PRIMARY KEY ([Id]) 
)
