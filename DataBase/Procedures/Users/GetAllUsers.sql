CREATE PROCEDURE [dbo].[GetAllUsers]
AS
SELECT 
	Id,
	NationalNumber,
	LastName, 
	FirstName, 
	Birthdate, 
	AdCity, 
	AdPostalCode, 
	AdStreet, 
	AdNumber, 
	AdBox, 
	MobilePhone,
	[Login],
	Gender,
	Photo,
	PersonalNote,
	StartDate, 
	Email, 
	ClassId, 
	StatusCode = dbo.StatusCode(Id)
	FROM ViewUsers
