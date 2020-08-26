CREATE PROCEDURE [dbo].[DeleteUserStatus_OneByOne]
	@userId int,
	@statusId int
AS
BEGIN
	DELETE FROM User_Status WHERE UserId = @userId AND StatusId = @statusId
END