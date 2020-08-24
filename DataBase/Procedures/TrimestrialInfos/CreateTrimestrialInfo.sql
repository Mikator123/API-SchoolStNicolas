CREATE PROCEDURE [dbo].[CreateTrimestrialInfo]
	@description nvarchar(MAX),
	@trimester int,
	@userId int
AS
BEGIN
	INSERT INTO TrimestrialInfos (InfoDescription, Trimester, CreateInfoDate, UserId, ClassName)
		VALUES 
			(@description, @trimester, getdate(), @userId, (SELECT ClassName FROM Classes WHERE Id = (SELECT ClassId FROM Users WHERE Id = @userId)))
END


