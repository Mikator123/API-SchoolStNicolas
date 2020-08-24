CREATE PROCEDURE [dbo].[CreateLunch]
	@name nvarchar(50),
	@description nvarchar(MAX),
	@lunchDate date
AS

BEGIN
	INSERT INTO Lunches (LunchName, LunchDescription , LunchDate)
		VALUES
			(@name,@description, @lunchDate)
END
