CREATE PROCEDURE [dbo].[UpdateQuestion]
	@id int,
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
	UPDATE Questions SET
		Question = @question,
		Correction = @correction,
		Explanation = @explanation,
		FirstHint = @firstHint,
		SecondHint = @secondHint,
		SchoolYear = @schoolYear,
		CategoryId = @categoryId,
		Trimester = @trimester,
		SchoolYearCategoryId = @schoolYearCategoryId,
		[Subject] = @subject,
		LastUpdate = GETDATE()
	WHERE Id = @id
END
