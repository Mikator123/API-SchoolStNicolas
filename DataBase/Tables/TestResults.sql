CREATE TABLE [dbo].[TestResults]
(
	[Id] INT IDENTITY NOT NULL, 
    [TestDate] DATE NOT NULL, 
    [Result] FLOAT NOT NULL, 
    [TestDescription] NVARCHAR(MAX) NULL, 
    [CategoryId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [ClassId] INT NOT NULL, 
    CONSTRAINT [PK_TestResults] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TestResults_Users] FOREIGN KEY (UserId) REFERENCES Users(Id), 
    CONSTRAINT [FK_TestResults_Classes] FOREIGN KEY (ClassId) REFERENCES Classes(Id), 
    CONSTRAINT [FK_TestResults_Categories] FOREIGN KEY (CategoryId) REFERENCES Categories(Id), 
    CONSTRAINT [CK_TestResults_Result] CHECK (RESULT <= 20 AND Result >= 0) 
)
