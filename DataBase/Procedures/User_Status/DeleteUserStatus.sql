CREATE PROCEDURE [dbo].[DeleteUserStatus]
	@id int
AS
BEGIN
	DELETE FROM User_Status WHERE UserId = @id
END

