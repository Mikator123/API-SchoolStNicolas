CREATE TABLE [dbo].[TestResults]
(
	[Id] INT IDENTITY NOT NULL, 
    [TestDate] DATE NOT NULL, 
    [Result] FLOAT NOT NULL, 
    [TestDescription] NVARCHAR(MAX) NULL, 
    [CategoryId] INT NULL, 
    [UserId] INT NOT NULL, 
    [ClassId] INT NULL, 
    CONSTRAINT [PK_TestResults] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TestResults_Users] FOREIGN KEY (UserId) REFERENCES Users(Id), 
    CONSTRAINT [FK_TestResults_Classes] FOREIGN KEY (ClassId) REFERENCES Classes(Id) ON DELETE SET NULL, 
    CONSTRAINT [FK_TestResults_Categories] FOREIGN KEY (CategoryId) REFERENCES Categories(Id) ON DELETE SET NULL, 
    CONSTRAINT [CK_TestResults_Result] CHECK (RESULT <= 20 AND Result >= 0) 
)
