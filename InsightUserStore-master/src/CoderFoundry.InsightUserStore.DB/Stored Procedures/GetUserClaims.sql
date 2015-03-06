CREATE PROCEDURE [Security].[GetUserClaims]
@userid int
AS
SELECT * FROM security.userclaims where userclaims.userid = @userid