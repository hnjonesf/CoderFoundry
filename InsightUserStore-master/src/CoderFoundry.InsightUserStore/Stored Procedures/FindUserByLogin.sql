CREATE PROCEDURE [Security].[FindUserByLogin]
@loginProvider nvarchar(128), @providerKey nvarchar(128)
as
SELECT u.*
FROM [Security].[Users] AS u
INNER JOIN Security.UserLogins AS 1 ON u.Id = 1.UserId
WHERE (1.LoginProvider = @LoginProvider)
	AND (1.ProviderKey = @providerKey)