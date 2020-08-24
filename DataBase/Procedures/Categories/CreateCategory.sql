CREATE PROCEDURE [dbo].[CreateCategory]
	@name nvarchar(50)
AS
BEGIN
	INSERT INTO Categories VALUES (@name)
END