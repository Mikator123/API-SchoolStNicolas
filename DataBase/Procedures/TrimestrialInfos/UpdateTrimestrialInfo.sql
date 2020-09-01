CREATE PROCEDURE [dbo].[UpdateTrimestrialInfo]
	@id int,
	@description nvarchar(MAX),
	@trimester int,
	@userId int
AS
BEGIN
	UPDATE TrimestrialInfos SET
		InfoDescription = @description,
		Trimester = @trimester,
		UpdateInfoDate = getdate(),
		UserId = @userId,
		ClassName = (SELECT ClassName FROM Classes WHERE Id = (SELECT ClassId FROM Users WHERE Id = @userId))
	WHERE Id = @id
END
