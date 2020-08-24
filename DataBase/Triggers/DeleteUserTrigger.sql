CREATE TRIGGER [dbo].[DeleteUserTrigger]
ON Users
INSTEAD OF DELETE
AS
	BEGIN
		DECLARE @id int;
		SET @id = (SELECT Id FROM deleted)
		UPDATE Users 
			SET 
				IsActive = 0,
				EndDate = getdate(),
				ClassId = null
			WHERE Id = @id;
	END


