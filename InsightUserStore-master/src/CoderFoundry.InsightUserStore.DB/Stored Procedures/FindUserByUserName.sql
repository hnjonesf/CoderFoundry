CREATE PROCEDURE [Security].[FindUserByUserName]
@username nvarchar(128)
as
SELECT u.*
FROM [Security].[Users] AS u
WHERE (u.UserName = @username)