CREATE TABLE [dbo].[Classes]
(
	[Id] INT Identity NOT NULL, 
    [ClassName] NVARCHAR(50) UNIQUE NOT NULL, 
    [ClassInfos] NVARCHAR(MAX) NULL, 
    [ProfessorId] INT NOT NULL, 
    CONSTRAINT [PK_Classes] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Classes_ToProfessors] FOREIGN KEY (ProfessorId) REFERENCES Professors(Id) 
)
