CREATE PROCEDURE [dbo].[DeleteUserLunch_OneByOneLunch]
	@userId int,
	@lunchId int
AS
BEGIN
	DELETE FROM User_Lunch WHERE LunchId = @lunchId AND UserId = @userId
END
