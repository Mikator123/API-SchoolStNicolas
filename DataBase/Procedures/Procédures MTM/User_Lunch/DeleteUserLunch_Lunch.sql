CREATE PROCEDURE [dbo].[DeleteUserLunch_Lunch]
	@id int
AS
BEGIN
	DELETE FROM User_Lunch WHERE LunchId = @id
END
