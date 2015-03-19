CREATE PROCEDURE [Security].[GetUserClaimsByUserId]
@userId int AS
SELECT r.[Name]
FROM [Security].[Roles] r JOIN
[Security].[UserRoles] ur
ON r.[Id] = ur.[RoleId]
WHERE ur.UserId = @userId
GO

