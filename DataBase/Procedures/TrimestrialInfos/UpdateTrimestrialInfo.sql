CREATE PROCEDURE [dbo].[UpdateTrimestrialInfo]
	@id int,
	@descrition nvarchar(MAX),
	@trimester int,
	@userId int
AS
BEGIN
	UPDATE TrimestrialInfos SET
		InfoDescription = @descrition,
		Trimester = @trimester,
		UpdateInfoDate = getdate(),
		UserId = @userId,
		ClassName = (SELECT ClassName FROM Classes WHERE Id = (SELECT ClassId FROM Users WHERE Id = @userId))
	WHERE Id = @id
END
