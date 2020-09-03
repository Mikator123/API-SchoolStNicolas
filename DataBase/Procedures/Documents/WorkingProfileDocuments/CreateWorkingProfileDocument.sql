CREATE PROCEDURE [dbo].[CreateWorkingProfileDocument]
	@description nvarchar(MAX),
	@link nvarchar(MAX),
	@name nvarchar(50),
	@categoryId int,
	@schoolYear int,
	@trimester int,
	@schoolyearNameId int
AS
BEGIN
	INSERT INTO WorkingProfileDocuments (DocumentDescription, DocumentName, DocumentLink, CategoryId, SchoolYear, Trimester, SchoolYearNameId)
		VALUES
			(@description, @name, @link, @categoryId, @schoolYear, @trimester, @schoolyearNameId)
END