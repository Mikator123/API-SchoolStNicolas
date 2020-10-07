CREATE PROCEDURE [dbo].ResetPwdUser
	@id int,
	@password nvarchar(50),
	@resetPwd date
AS
BEGIN
	UPDATE Users SET
	Password = HASHBYTES('SHA2_512',dbo.PreSalt()+@password+dbo.PostSalt()),
	FirstLogin = @resetPwd
	WHERE Id = @id
END