CREATE PROCEDURE [Security].[FindUserByUserName]
@username(128)
as
SELECT u.*
FROM [Security].[Users] AS u
WHERE (u.LoginUser = @username)