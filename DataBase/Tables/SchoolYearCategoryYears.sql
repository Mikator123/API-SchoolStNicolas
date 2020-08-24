CREATE TABLE [dbo].[SchoolYearCategoryYears]
(
	[Id] INT Identity NOT NULL, 
    [CategoryYear] INT UNIQUE NOT NULL, 
    CONSTRAINT [PK_SchoolYearCategoryYears] PRIMARY KEY ([Id]) 
)
