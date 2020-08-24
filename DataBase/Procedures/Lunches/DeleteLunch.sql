CREATE PROCEDURE [dbo].[DeleteLunch]
	@id int
AS
BEGIN
	DELETE FROM Lunches WHERE Id = @id
END
