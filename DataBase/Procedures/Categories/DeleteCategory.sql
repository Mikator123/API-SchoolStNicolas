CREATE PROCEDURE [dbo].[DeleteCategory]
	@id int
AS
BEGIN
	DELETE FROM Categories WHERE Id = @id
END
