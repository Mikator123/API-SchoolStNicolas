CREATE PROCEDURE [dbo].[DeleteUserContact]
	@userId int
AS
	BEGIN
		DELETE FROM User_Contact WHERE UserId = @userId
	END
