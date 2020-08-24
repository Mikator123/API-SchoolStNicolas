﻿CREATE PROCEDURE [dbo].[CreateContact]
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
	@personnalNote nvarchar(MAX)
AS
BEGIN
	INSERT INTO Contacts 
		(NationalNumber, LastName, FirstName, Birthdate, AdCity, AdPostalCode, AdStreet, AdNumber, AdBox, MobilePhone,
		Gender, Email, PersonnalNote)
		VALUES
			(@nationalNumber, @lastName, @firstName, @birthdate, @adCity, @adPostalCode, @adStreet, @adNumber, @adBox, @mobilePhone,
			@gender, @email, @personnalNote)
END	
BEGIN
	DECLARE @id INT = (SELECT Id FROM Contacts WHERE NationalNumber = @nationalNumber)
	RETURN @id
END