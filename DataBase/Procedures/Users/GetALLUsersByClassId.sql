CREATE PROCEDURE [dbo].[GetALLUsersByClassId]
	@classId int
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
	WHERE ClassId = @classId
