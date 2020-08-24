CREATE PROCEDURE [dbo].[CreateClass]
	@name nvarchar(50),
	@description nvarchar(MAX),
	@schoolYear int,
	@schoolYearCategoryId int

AS
BEGIN
	IF NOT EXISTS (SELECT Id FROM Classes WHERE ClassName = @name)
	BEGIN
		INSERT INTO Classes (ClassName, ClassDescription, SchoolYear, SchoolYearCategoryId)
			VALUES
				(@name, @description, @schoolYear, @schoolYearCategoryId)
	END
	ELSE
	BEGIN
		DECLARE @id int = (SELECT Id FROM Classes WHERE ClassName = @name)
		EXEC dbo.UpdateClass @id, @name, @description, @schoolYear, @schoolYearCategoryId
	END
END
