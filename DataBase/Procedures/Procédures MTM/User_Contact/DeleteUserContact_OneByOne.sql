CREATE PROCEDURE [dbo].[DeleteUserContact_OneByOne]
	@userId int,
	@contactId int
AS
	BEGIN
		DELETE FROM User_Contact WHERE UserId = @userId AND ContactId = @contactId
	END
