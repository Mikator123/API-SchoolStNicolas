CREATE PROCEDURE [dbo].[UpdateWorkingProfileDocument]
	@Id int,
	@description nvarchar(MAX),
	@link nvarchar(MAX),
	@name nvarchar(50),
	@categoryId int,
	@schoolYear int,
	@trimester int,
	@schoolyearNameId int
AS
BEGIN
	UPDATE WorkingProfileDocuments SET
		DocumentDescription = @description,
		DocumentLink = @link,
		DocumentName = @name,
		CategoryId = @categoryId,
		SchoolYear = @schoolYear,
		Trimester = @trimester,
		SchoolYearNameId = @schoolyearNameId
		WHERE Id = @Id
END
