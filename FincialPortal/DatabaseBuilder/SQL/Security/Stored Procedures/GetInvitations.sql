CREATE PROCEDURE [dbo].[GetInvitations]
	@email NVARCHAR(256)
AS
BEGIN
	SELECT	Invitations.Id AS Id,
			Users.Name AS FromUserName,
			Households.Id AS HouseholdId,
			Households.Name AS UserHouse
	FROM [dbo].[Invitations]
	INNER JOIN [Security].[Users] ON Users.Id = FromUserID 
	INNER JOIN [Security].Households ON Households.Id = Users.HouseholdId
	WHERE ToEmail = @email
END
GO 
