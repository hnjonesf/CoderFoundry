CREATE PROCEDURE [Security].[GetUserLoginsByUserId]
@userid int
AS
SELECT * FROM security.userlogins where u = @userid
