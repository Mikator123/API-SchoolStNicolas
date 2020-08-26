CREATE PROCEDURE [dbo].[CreateUser]
	@nationalNumber nvarchar(50),
	@lastName nvarchar(50),
	@firstName nvarchar(50),
	@birthdate date,
	@adCity nvarchar(50),
	@adPostalCode int,
	@adStreet nvarchar(50),
	@adNumber int,
	@adBox nvarchar(5),
	@mobilePhone nvarchar(50),
	@gender nvarchar(5),
	@photo nvarchar(MAX),
	@personalNote nvarchar(MAX),
	@startDate date,
	@email nvarchar(320),
	@password nvarchar(50),
	@classId int

AS
BEGIN
	DECLARE @testId INT = (SELECT Id FROM Users WHERE NationalNumber = @nationalNumber and IsActive = 0 and Birthdate = @birthdate)
	IF (@testId != null)
	BEGIN
		UPDATE Users SET
			IsActive = 1,
			StartDate = @startDate
			WHERE Id = @testId
	END
	ELSE
	BEGIN
	DECLARE @login nvarchar(50) = SUBSTRING(UPPER(@firstName), 1,1)+''+SUBSTRING(UPPER(@lastName), 1,1)+''+SUBSTRING(LOWER(@lastName),2, LEN(@lastName));

	IF NOT EXISTS (SELECT [Login] from Users where [Login] = @login)
		BEGIN
				INSERT INTO Users 
				(NationalNumber, LastName, FirstName, Birthdate, AdCity, AdPostalCode, AdStreet, AdNumber, AdBox, MobilePhone,
				Gender, Photo, PersonalNote, StartDate, Email, ClassId, [Login], [Password])
				VALUES 
					(@nationalNumber, @lastName, @firstName, @birthdate,@adCity, @adPostalCode, @adStreet
					, @adNumber,@adBox, @mobilePhone,
					@gender, @photo, @personalNote, @startDate, @email, @classId,
					@login, HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt()));
		END

	ELSE 
		BEGIN
			DECLARE @i int = 2
			SET @login = @login+CONVERT(nvarchar(50),@i)
			WHILE EXISTS (SELECT * from Users where [Login] = @login)
			BEGIN
				SET @i = @i +1
				SET @login = SUBSTRING(@login, 1, LEN(@login)-1)
				SET @login = @login+CONVERT(nvarchar(50),@i)
				
			END
				INSERT INTO Users 
				(NationalNumber, LastName, FirstName, Birthdate, AdCity, AdPostalCode, AdStreet, AdNumber, AdBox, MobilePhone,
				Gender, Photo, PersonalNote, StartDate, Email, ClassId, [Login], [Password])
				VALUES 
					(@nationalNumber, @lastName, @firstName, @birthdate,@adCity, @adPostalCode, @adStreet
					, @adNumber,@adBox, @mobilePhone,
					@gender, @photo, @personalNote, @startDate, @email, @classId,
					@login, HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt()));
		END

	DECLARE @id int = (SELECT Id FROM Users WHERE NationalNumber = @nationalNumber);
	RETURN @id
	END
END
