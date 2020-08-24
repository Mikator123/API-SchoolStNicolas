CREATE PROCEDURE [dbo].[UpdateCategory]
	@id int,
	@name nvarchar(50)
AS
BEGIN
	UPDATE Categories SET
		CategoryName = @name
		WHERE Id = @id
END
