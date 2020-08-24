CREATE PROCEDURE [dbo].[UpdateClass]
	@id int,
	@name nvarchar(50),
	@descritpion nvarchar(max),
	@schoolYear int,
	@schoolYearCategoryId int
AS
BEGIN
	UPDATE Classes SET
		ClassName = @name,
		ClassDescription = @descritpion,
		SchoolYear = @schoolYear,
		SchoolYearCategoryId = @schoolYearCategoryId
	WHERE Id = @id
END