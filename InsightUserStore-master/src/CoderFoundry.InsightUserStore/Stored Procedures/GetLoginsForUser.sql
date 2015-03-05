CREATE PROCEDURE [Security].[GetLoginsForUser]
@userId int
AS
SELECT * FROM security.userlogins where userid = @userId