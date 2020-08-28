CREATE FUNCTION [dbo].[StatusCode]
(
	@userId int
)
RETURNS INT
AS
BEGIN
	DECLARE @userStatus int = 0
	DECLARE @StatusTempo TABLE (StatusName nvarchar(50))
	INSERT INTO @StatusTempo SELECT StatusName FROM User_Status US JOIN [Status] S ON S.Id = US.StatusId WHERE UserId = @userId
	
	IF EXISTS (SELECT * FROM @StatusTempo WHERE StatusName = 'Student')
	BEGIN
		SET @userStatus = @userStatus + 1;
	END
	IF EXISTS (SELECT * FROM @StatusTempo WHERE StatusName = 'Professor')
	BEGIN
		SET @userStatus = @userStatus + 2;
	END
	IF EXISTS (SELECT * FROM @StatusTempo WHERE StatusName = 'Manager')
	BEGIN
		SET @userStatus = @userStatus + 4;
	END
	IF EXISTS (SELECT * FROM @StatusTempo WHERE StatusName = 'Admin')
	BEGIN
		SET @userStatus = @userStatus + 8;
	END
	RETURN @userStatus
END


	
