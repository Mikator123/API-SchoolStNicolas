﻿CREATE TABLE [dbo].[WorkingProfileDocuments]
(
	[Id] INT IDENTITY NOT NULL, 
    [DocumentDescription] NVARCHAR(MAX) NOT NULL, 
    [DocumentLink] NVARCHAR(MAX) NOT NULL, 
    [DocumentName] NVARCHAR(50) NOT NULL, 
    [CategoryId] INT NULL, 
    [SchoolYear] INT NOT NULL, 
    [Trimester] INT NOT NULL, 
    [SchoolYearNameId] INT NOT NULL, 
    CONSTRAINT [PK_WorkingProfileDocuments] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_WorkingProfileDocuments_Categories] FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE SET NULL, 
    CONSTRAINT [FK_WorkingProfileDocuments_SchoolYearCategoryNames] FOREIGN KEY ([SchoolYearNameId]) REFERENCES SchoolYearCategoryNames(Id),
        CONSTRAINT [CK_WorkingProfileDocument_Trimester] CHECK (Trimester BETWEEN 1 AND 3), 
)
