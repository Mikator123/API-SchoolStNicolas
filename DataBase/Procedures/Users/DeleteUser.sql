CREATE PROCEDURE [dbo].[DeleteUser]
	@id int
AS
BEGIN
	DELETE FROM Users WHERE Id = @id
END
