CREATE PROCEDURE [Security].[GetRolesForUser]
@role int
AS
SELECT * FROM security.userroles where userroles = @role