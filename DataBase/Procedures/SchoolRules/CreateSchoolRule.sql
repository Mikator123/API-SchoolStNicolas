CREATE PROCEDURE [dbo].[CreateSchoolRule]
	@name nvarchar(50),
	@description nvarchar(MAX)
AS
BEGIN

	IF NOT EXISTS (SELECT Id FROM SchoolRules WHERE RuleName = @name)
	BEGIN
		INSERT INTO SchoolRules (RuleName, RuleDescription)
			VALUES
				(@name, @description)
	END
	ELSE
	BEGIN
		DECLARE @id int = (SELECT Id FROM SchoolRules WHERE RuleName = @name)
		EXEC dbo.UpdateSchoolRule @id,@name, @description
	END
END
