CREATE TABLE [dbo].[SchoolYearCategoryNames]
(
	[Id] INT IDENTITY NOT NULL, 
    [CategoryName] NVARCHAR(50) UNIQUE NOT NULL, 
    CONSTRAINT [PK_SchoolYearCategoryNames] PRIMARY KEY ([Id]),
    CONSTRAINT [UK_SchoolYearCategoryNames_CategoryName] UNIQUE ([CategoryName])
)
