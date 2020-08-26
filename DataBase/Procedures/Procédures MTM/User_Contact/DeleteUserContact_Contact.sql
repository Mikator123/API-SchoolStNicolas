CREATE PROCEDURE [dbo].[DeleteUserContact_Contact]
	@ContactId int
AS
	BEGIN
		DELETE FROM User_Contact WHERE ContactId = @ContactId
	END
