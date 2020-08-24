﻿CREATE PROCEDURE [dbo].[UpdateSchoolRule]
	@id int null,
	@name nvarchar(50),
	@descritpion nvarchar(max)
AS
BEGIN
	UPDATE SchoolRules SET
		RuleName = @name,
		RuleDescription = @descritpion
	WHERE Id = @id
END