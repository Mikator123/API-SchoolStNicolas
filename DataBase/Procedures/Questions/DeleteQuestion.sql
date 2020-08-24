CREATE PROCEDURE [dbo].[DeleteQuestion]
	@id int
AS
BEGIN
	DELETE FROM Questions WHERE Id = @id
END
