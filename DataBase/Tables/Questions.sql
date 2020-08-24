﻿CREATE TABLE [dbo].[Questions]
(
	[Id] INT IDENTITY NOT NULL, 
    [Question] NVARCHAR(MAX) NOT NULL, 
    [Correction] NVARCHAR(MAX) NOT NULL, 
    [Explanation] NVARCHAR(MAX) NOT NULL,
    [FirstHint] NVARCHAR(MAX) NOT NULL, 
    [SecondHint] NVARCHAR(MAX) NULL, 
    [CategoryId] INT NOT NULL, 
    [SchoolYear] INT NOT NULL, 
    [Trimester] INT NOT NULL, 
    [SchoolYearCategoryId] INT NOT NULL, 
    CONSTRAINT [PK_Questions] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Questions_Categories] FOREIGN KEY (CategoryId) REFERENCES Categories(Id), 
    CONSTRAINT [CK_Questions_Trimester] CHECK (Trimester BETWEEN 0 AND 5), 
    CONSTRAINT [FK_Questions_SchoolYearCategoryNames] FOREIGN KEY ([SchoolYearCategoryId]) REFERENCES SchoolYearCategoryNames(Id), 
)
