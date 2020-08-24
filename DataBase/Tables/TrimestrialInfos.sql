CREATE TABLE [dbo].[TrimestrialInfos]
(
	[Id] INT IDENTITY NOT NULL, 

    [UserId] INT NOT NULL, 
    [InfoDescription] NVARCHAR(MAX) NOT NULL, 
    [CreateInfoDate] DATE NOT NULL, 
    [UpdateInfoDate] DATE NULL, 
    [ClassName] NVARCHAR(50) NOT NULL,
    [Trimester] INT NOT NULL, 
    CONSTRAINT [PK_TrimestrialInfos] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TrimestrialInfos_Users] FOREIGN KEY (UserId) REFERENCES Users(Id), 
    CONSTRAINT [CK_TrimestrialInfos_YearQuarter] CHECK ([Trimester] = 1 or [Trimester] = 2 or [Trimester] = 3)
    
)
