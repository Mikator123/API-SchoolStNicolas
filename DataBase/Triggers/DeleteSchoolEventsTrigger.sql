CREATE TRIGGER [dbo].[DeleteSchoolEventsTrigger]
    ON [dbo].[SchoolEvents]
    INSTEAD OF DELETE
    AS
	BEGIN
		DECLARE @id int;
		SET @id = (SELECT Id FROM deleted)
		UPDATE [SchoolEvents] 
			SET 
				IsActive = 0

			WHERE Id = @id;
	END