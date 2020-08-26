CREATE FUNCTION [dbo].[StatusEnumeration]
(
	@userId int
)
RETURNS INT
AS
BEGIN
	DECLARE @userStatus int = 0
	DECLARE @StatusCheckTable TABLE (StatusName nvarchar(50));
	INSERT INTO @StatusCheckTable (StatusName)
		VALUES
			((SELECT StatusName FROM User_Status US JOIN [Status] S ON S.Id = US.StatusId WHERE UserId = @userId))

	IF EXISTS (SELECT * FROM @StatusCheckTable WHERE StatusName = 'Student')
	BEGIN
		SET @userStatus = @userStatus + 1;
	END
	IF EXISTS (SELECT * FROM @StatusCheckTable WHERE StatusName = 'Professor')
	BEGIN
		SET @userStatus = @userStatus + 2;
	END
	IF EXISTS (SELECT * FROM @StatusCheckTable WHERE StatusName = 'Manager')
	BEGIN
		SET @userStatus = @userStatus + 4;
	END
	IF EXISTS (SELECT * FROM @StatusCheckTable WHERE StatusName = 'Admin')
	BEGIN
		SET @userStatus = @userStatus + 8;
	END
		

	RETURN @userStatus
END

