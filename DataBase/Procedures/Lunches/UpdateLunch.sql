CREATE PROCEDURE [dbo].[UpdateLunch]
	@id int,
	@name nvarchar(50),
	@description nvarchar(MAX),
	@lunchDate date
AS
BEGIN
	UPDATE Lunches SET
		LunchName = @name,
		LunchDescription = @description,
		LunchDate = @lunchDate
		WHERE Id = @id
END