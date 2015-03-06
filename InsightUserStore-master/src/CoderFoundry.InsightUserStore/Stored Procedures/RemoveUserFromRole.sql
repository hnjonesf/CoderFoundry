CREATE PROCEDURE [Security].[RemoveUserFromRole]
@userId int, @role nvarchar(50)
AS

delete ur
from [Security].[UserRoles] ur
join [Security].[Roles] r on r.[Name] = @role
where ur.UserId = @userId AND r.[Name] = @role