CREATE TRIGGER [dbo].[DeleteContactTrigger]
ON Contacts
INSTEAD OF DELETE
AS
	BEGIN
		DECLARE @id int;
		SET @id = (SELECT Id FROM deleted)
		UPDATE Contacts 
			SET 
				IsActive = 0
			WHERE Id = @id;
	END