CREATE PROCEDURE [dbo].[DeleteWorkingProfileDocument]
	@Id int
AS
BEGIN
	DELETE FROM WorkingProfileDocuments WHERE Id = @Id
END
