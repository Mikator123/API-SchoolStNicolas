CREATE PROCEDURE [dbo].[DeleteUserLunch_User]
	@id int
AS
BEGIN
	DELETE FROM User_Lunch WHERE UserId = @id
END
