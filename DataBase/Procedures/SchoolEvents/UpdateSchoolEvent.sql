CREATE PROCEDURE [dbo].[UpdateSchoolEvent]
	@id int,
	@name nvarchar(50),
	@descritpion nvarchar(max),
	@date date
AS
BEGIN
	UPDATE SchoolEvents SET
		EventName = @name,
		EventDescription = @descritpion,
		EventDate = @date
	WHERE Id = @id
END
