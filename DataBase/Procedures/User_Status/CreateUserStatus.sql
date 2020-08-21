CREATE PROCEDURE [dbo].[CreateUserStatus]
	@id int,
	@statusId int
AS
BEGIN
	INSERT INTO User_Status(UserId, StatusId) VALUES
		(@id, @statusId)
END