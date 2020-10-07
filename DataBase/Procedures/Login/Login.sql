CREATE PROCEDURE [dbo].[Login]
	@login nvarchar(50),
	@password nvarchar(50)
AS
BEGIN
	IF NOT EXISTS (SELECT Id FROM ViewUsers where [Login] = @login)
	BEGIN
		RAISERROR ('LoginNotFound', 17,1);
	END
	ELSE IF NOT EXISTS (SELECT Id FROM ViewUsers WHERE [Login] = @login AND [Password] = HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt())) 
	BEGIN
		RAISERROR ('PasswordDoesntMatch',17,1)
	END
	ELSE
	BEGIN
		SELECT 
			Id, 
			LastName,
			FirstName,
			Birthdate,
			[Login],
			Gender,
			FirstLogin,
			ClassId,
			StatusCode = dbo.StatusCode(Id)
			FROM ViewUsers WHERE [Login] = @login AND [Password] = HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt())
	END
END
