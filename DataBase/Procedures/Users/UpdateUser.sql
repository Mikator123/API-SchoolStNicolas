CREATE PROCEDURE [dbo].[UpdateUser]
	@id int,
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
	@photo nvarchar(300),
	@personalNote nvarchar(MAX),
	@startDate date,
	@email nvarchar(320),
	@classId int,
	@password nvarchar(50)
AS 
BEGIN
	DECLARE @oldLogin nvarchar(50), @oldLastName nvarchar(50), @oldFirstName nvarchar(50);
	SET @oldLogin= (SELECT [Login] FROM Users WHERE Id = @id);
	SET @oldLastName = (SELECT LastName FROM Users WHERE Id = @id);
	SET @oldFirstName = (SELECT FirstName FROM Users WHERE Id = @id);

	IF (@oldLastName = @lastName AND SUBSTRING(UPPER(@oldFirstName), 1,1) = SUBSTRING(UPPER(@firstName), 1,1))
		BEGIN	
		UPDATE Users SET 
				NationalNumber = @nationalNumber,
				LastName = @lastName,
				FirstName = @firstName,
				Birthdate = @birthdate,
				AdCity = @adCity,
				AdPostalCode = @adPostalCode,
				AdStreet = @adStreet,
				AdNumber = @adNumber,
				AdBox = @adBox,
				MobilePhone = @mobilePhone,
				Gender = @gender,
				Photo = @photo,
				PersonalNote = @personalNote,
				StartDate = @startDate,
				Email = @email,
				ClassId = @classId,
				[Password] = HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt())
			WHERE Id = @id;

		END
	ELSE 
		BEGIN
			DECLARE @login nvarchar(50) = SUBSTRING(UPPER(@firstName), 1,1)+''+SUBSTRING(UPPER(@lastName), 1,1)+''+SUBSTRING(LOWER(@lastName),2, LEN(@lastName));
			IF NOT EXISTS (SELECT [Login] from Users where [Login] = @login)
			BEGIN
				UPDATE Users SET 
				NationalNumber = @nationalNumber,
				LastName = @lastName,
				FirstName = @firstName,
				Birthdate = @birthdate,
				AdCity = @adCity,
				AdPostalCode = @adPostalCode,
				AdStreet = @adStreet,
				AdNumber = @adNumber,
				AdBox = @adBox,
				MobilePhone = @mobilePhone,
				Gender = @gender,
				Photo = @photo,
				PersonalNote = @personalNote,
				StartDate = @startDate,
				Email = @email,
				ClassId = @classId,
				[Password] = HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt()),
				[Login] = @login
				WHERE Id = @id;

			END
			ELSE 
				BEGIN
					DECLARE @i int = 2
					SET @login = @login+CONVERT(nvarchar(50),@i)
					WHILE EXISTS (SELECT Id from Users where [Login] = @login)
						BEGIN
							SET @i = @i +1
							SET @login = SUBSTRING(@login, 1, LEN(@login)-1)
							SET @login = @login+CONVERT(nvarchar(50),@i)
						END
						UPDATE Users SET 
							NationalNumber = @nationalNumber,
							LastName = @lastName,
							FirstName = @firstName,
							Birthdate = @birthdate,
							AdCity = @adCity,
							AdPostalCode = @adPostalCode,
							AdStreet = @adStreet,
							AdNumber = @adNumber,
							AdBox = @adBox,
							MobilePhone = @mobilePhone,
							Gender = @gender,
							Photo = @photo,
							PersonalNote = @personalNote,
							StartDate = @startDate,
							Email = @email,
							ClassId = @classId,
							[Password] = HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt()),
							[Login] = @login
							WHERE Id = @id;
				END
		END
END
