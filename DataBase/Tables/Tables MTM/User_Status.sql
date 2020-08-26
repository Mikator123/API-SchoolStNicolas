CREATE TABLE [dbo].[User_Status]
(
	[UserId] INT NOT NULL, 
    [StatusId] INT NOT NULL,
    CONSTRAINT [FK_User_Status_UserId] FOREIGN KEY (UserId) REFERENCES Users(Id), 
    CONSTRAINT [FK_User_Status_StatusId] FOREIGN KEY (StatusId) REFERENCES [Status](Id), 
    CONSTRAINT [PK_User_Status] PRIMARY KEY ([UserId],[StatusId]) 
)
