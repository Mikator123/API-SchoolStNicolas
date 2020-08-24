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
		EXEC dbo.UpdateSchoolRule null,@name, @description
	END
END
