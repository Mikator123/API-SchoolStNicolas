CREATE PROCEDURE [dbo].[DeleteTrimestrialInfo]
	@id int
AS
	BEGIN
		DELETE FROM TrimestrialInfos WHERE Id = @id
	END
