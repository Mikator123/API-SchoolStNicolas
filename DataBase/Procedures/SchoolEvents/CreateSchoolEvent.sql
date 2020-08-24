CREATE PROCEDURE [dbo].[CreateSchoolEvent]
	@name nvarchar(50),
	@description nvarchar(MAX),
	@date date
AS
BEGIN

	IF NOT EXISTS (SELECT Id FROM SchoolEvents WHERE EventName = @name)
	BEGIN
		INSERT INTO SchoolEvents (EventName, EventDescription, EventDate)
			VALUES
				(@name, @description, @date)
	END
	ELSE
	BEGIN
		EXEC dbo.UpdateSchoolEvent null,@name, @description, @date
	END
END
	