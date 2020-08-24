CREATE PROCEDURE [dbo].[CreateUserContact]
	@userId int,
	@contactId int
AS
	BEGIN
		INSERT INTO User_Contact (UserId, ContactId)
			VALUES
				(@userId, @contactId)
	END
