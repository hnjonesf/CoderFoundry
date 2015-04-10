CREATE PROCEDURE [Security].[GetUserInfo]
	@userId int
AS
BEGIN
	SELECT	[Security].[Users].Id, 
			[Security].[Users].UserName, 
			[Security].[Users].Email, 
			[Security].[Users].PhoneNumber 
	FROM [Security].[Users]
	WHERE [Security].[Users].Id = @userId
END
GO