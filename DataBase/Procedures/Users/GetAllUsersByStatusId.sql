CREATE PROCEDURE [dbo].[GetAllUsersByStatusId]
	@statusId int
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
	FROM User_Status US JOIN ViewUsers U ON U.Id = US.UserId WHERE StatusId = @statusId
	