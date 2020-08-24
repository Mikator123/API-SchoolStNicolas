CREATE PROCEDURE [dbo].[CreateUserLunch]
	@userId int,
	@lunchId int
AS
BEGIN
	INSERT INTO User_Lunch (UserId, LunchId)
		VALUES
			(@userId, @lunchId)
END