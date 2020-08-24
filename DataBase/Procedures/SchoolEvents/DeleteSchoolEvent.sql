CREATE PROCEDURE [dbo].[DeleteSchoolEvent]
	@id int,
	@nbrOfPersons int
AS
BEGIN
	UPDATE SchoolEvents 
		SET
		NbrOfPersons = @nbrOfPersons
		WHERE Id = @id
END
BEGIN
	DELETE FROM SchoolEvents WHERE Id = @id
END