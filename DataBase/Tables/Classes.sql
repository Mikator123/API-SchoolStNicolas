CREATE TABLE [dbo].[Classes]
(
	[Id] INT Identity NOT NULL, 
    [ClassName] NVARCHAR(50) NOT NULL, 
    [ClassDescription] NVARCHAR(MAX) NULL,
    [SchoolYear] INT NOT NULL, 
    [SchoolYearCategoryId] INT NOT NULL, 

    CONSTRAINT [PK_Classes] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Classes_SchoolYearCategoryNames] FOREIGN KEY (SchoolYearCategoryId) REFERENCES SchoolYearCategoryNames(Id), 
    CONSTRAINT [CK_Classes_ClassName] UNIQUE (ClassName), 
)

