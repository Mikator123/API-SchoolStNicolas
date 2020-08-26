CREATE TABLE [dbo].[User_Contact]
(
	[UserId] INT,
	[ContactId] INT
    CONSTRAINT [FK_User_Contact_UserId] FOREIGN KEY (UserId) REFERENCES Users(Id), 
    CONSTRAINT [FK_User_Contact_ContactId] FOREIGN KEY (ContactId) REFERENCES Contacts(Id), 
    CONSTRAINT [PK_User_Contact] PRIMARY KEY ([UserId], [ContactId])
)
