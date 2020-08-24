CREATE PROCEDURE [dbo].[DeleteUserLunch]
	@id int
AS
BEGIN
	DELETE FROM User_Lunch WHERE UserId = @id
END
