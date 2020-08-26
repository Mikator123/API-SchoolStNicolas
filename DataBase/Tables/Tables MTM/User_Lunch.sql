CREATE TABLE [dbo].[User_Lunch]
(
	[UserId] INT NOT NULL,
	[LunchId] INT NOT NULL, 
    CONSTRAINT [FK_User_Lunch_Lunches] FOREIGN KEY (LunchId) REFERENCES Lunches(Id), 
    CONSTRAINT [FK_User_Lunch_Users] FOREIGN KEY (UserId) REFERENCES Users(Id), 
    CONSTRAINT [PK_User_Lunch] PRIMARY KEY ([UserId],[LunchId])
)
