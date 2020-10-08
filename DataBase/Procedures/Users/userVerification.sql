CREATE PROCEDURE [dbo].[userVerification]
	@login nvarchar(50),
	@userNationalNumber nvarchar(50),
	@contactNationalNumber nvarchar(50)
AS
	BEGIN
		DECLARE @id int
		IF EXISTS (SELECT Id FROM ViewUsers where [Login] = @login)
			BEGIN
				SET @id = (SELECT Id FROM ViewUsers where [Login] = @login)
			END
		IF NOT EXISTS (SELECT Id FROM ViewUsers where [Login] = @login)
			BEGIN
				RAISERROR ('LoginNotFound', 17,1);
			END
		ELSE IF NOT EXISTS (SELECT Id FROM ViewUsers WHERE Id = @id AND NationalNumber = @userNationalNumber)
			BEGIN
				RAISERROR ('userNN does not match', 17,1);
			END
		ELSE IF NOT EXISTS (SELECT * FROM User_Contact WHERE UserId = @id AND ContactId = (SELECT Id FROM Contacts WHERE NationalNumber = @contactNationalNumber))
			BEGIN
				RAISERROR ('contactNN does not match', 17,1);
			END
		ELSE 
			SELECT Id FROM ViewUsers where [Login] = @login
	END

