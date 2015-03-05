CREATE PROCEDURE [Security].[GetUserClaims]
@claim int
AS
SELECT * FROM security.userclaims where userclaims = @claim