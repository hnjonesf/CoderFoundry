CREATE PROCEDURE [Security].[FindUserByLogin]
@userId int, @role nvarchar(50)
AS

INSERT INTO [Security].[UserRoles] (UserId, RoleId)
SELECT @userId, r.Id
FROM [Security].[Roles] r
WHERE r.Name = @role
/* comment format*/
SELECT convert (BIT, CASE @@ROWCOUNT
				WHEN 0 THEN 0
				ELSE 1
				END)