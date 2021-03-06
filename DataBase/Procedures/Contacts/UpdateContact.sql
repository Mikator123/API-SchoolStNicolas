﻿CREATE PROCEDURE [dbo].[UpdateContact]
	@id INT,
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
	@email nvarchar(320),
	@personalNote nvarchar(MAX)
AS
BEGIN
	if(@mobilePhone is null)
		BEGIN
			SET @mobilePhone = 'N/A'
		END
	if(@email is null)
		BEGIN
			SET @email = 'N/A'
		END
	UPDATE Contacts SET
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
		Email = @email,
		PersonalNote = @personalNote
		WHERE Id = @id
END
