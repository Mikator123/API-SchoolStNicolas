CREATE PROCEDURE [dbo].[DeleteClass]
	@id int
AS

BEGIN
	DELETE FROM Classes WHERE Id = @id
END