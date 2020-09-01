CREATE PROCEDURE [dbo].[UpdateClass]
	@id int,
	@name nvarchar(50),
	@description nvarchar(max),
	@schoolYear int,
	@schoolYearCategoryId int
AS
BEGIN
	UPDATE Classes SET
		ClassName = @name,
		ClassDescription = @description,
		SchoolYear = @schoolYear,
		SchoolYearCategoryId = @schoolYearCategoryId
	WHERE Id = @id
END