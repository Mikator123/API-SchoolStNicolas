CREATE PROCEDURE [dbo].[GetUser]
	@id int
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
	StatusCode = dbo.StatusCode(@id)
	FROM ViewUsers
	WHERE Id = @id