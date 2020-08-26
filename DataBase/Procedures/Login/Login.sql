CREATE PROCEDURE [dbo].[Login]
	@login nvarchar(50),
	@password nvarchar(50)
AS
BEGIN
	SELECT 
		Id, 
		LastName,
		FirstName,
		Birthdate,
		[Login],
		Gender,
		FirstLogin,
		StatusCode = dbo.StatusEnumeration(Id)
		FROM ViewUsers WHERE [Login] = @login AND [Password] = HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt())
END
