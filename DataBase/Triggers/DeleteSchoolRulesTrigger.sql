CREATE TRIGGER [dbo].[DeleteSchoolRulesTrigger]
    ON [dbo].[SchoolRules]
    INSTEAD OF DELETE
    AS
	BEGIN
		DECLARE @id int;
		SET @id = (SELECT Id FROM deleted)
		UPDATE SchoolRules 
			SET 
				IsActive = 0
			WHERE Id = @id;
	END