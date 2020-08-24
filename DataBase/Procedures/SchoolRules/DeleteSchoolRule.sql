CREATE PROCEDURE [dbo].[DeleteSchoolRule]
	@id int
AS
BEGIN
	DELETE FROM SchoolRules WHERE Id = @id
END