CREATE PROCEDURE [dbo].[DeleteContact]
	@id int
AS
BEGIN
	DELETE FROM Contacts WHERE Id = @id
END
