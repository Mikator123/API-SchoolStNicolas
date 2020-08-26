CREATE PROCEDURE [dbo].[DeleteUserContact_User]
	@userId int
AS
	BEGIN
		DELETE FROM User_Contact WHERE UserId = @userId
	END
