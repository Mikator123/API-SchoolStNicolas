CREATE PROCEDURE [dbo].[UpdateSchoolRule]
	@id int,
	@name nvarchar(50),
	@description nvarchar(max)
AS
BEGIN
	UPDATE SchoolRules SET
		RuleName = @name,
		RuleDescription = @description
	WHERE Id = @id
END
