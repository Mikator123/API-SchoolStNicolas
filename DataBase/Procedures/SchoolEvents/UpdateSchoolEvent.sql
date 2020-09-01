CREATE PROCEDURE [dbo].[UpdateSchoolEvent]
	@id int,
	@name nvarchar(50),
	@description nvarchar(max),
	@date date
AS
BEGIN
	UPDATE SchoolEvents SET
		EventName = @name,
		EventDescription = @description,
		EventDate = @date
	WHERE Id = @id
END
