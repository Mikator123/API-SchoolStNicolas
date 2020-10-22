CREATE PROCEDURE [dbo].[CreateQuestion]
	@question nvarchar(MAX),
	@correction nvarchar(MAX),
	@explanation nvarchar(MAX),
	@firstHint nvarchar(MAX),
	@secondHint nvarchar(MAX),
	@schoolYear int,
	@categoryId int,
	@trimester int,
	@schoolYearCategoryId int,
	@subject nvarchar(MAX)
AS
BEGIN
	INSERT INTO Questions (Question, Correction, Explanation, FirstHint, SecondHint, SchoolYear, CategoryId, Trimester, SchoolYearCategoryId, [Subject], LastUpdate)
		VALUES
		(@question, @correction, @explanation, @firstHint, @secondHint, @schoolYear, @categoryId, @trimester, @schoolYearCategoryId, @subject, GETDATE())
END
