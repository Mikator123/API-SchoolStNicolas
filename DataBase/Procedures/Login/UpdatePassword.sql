CREATE PROCEDURE [dbo].[UpdatePassword]
	@id int,
	@password nvarchar(50)
AS
BEGIN
	UPDATE Users SET 
	[Password] = HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt())
	WHERE Id = @id
END