CREATE PROCEDURE [Security].[FindUserByEmail]
@email nvarchar(128)
AS
SELECT @email, r.Email
FROM Users r
WHERE r.Email = @email
/* comment format*/
SELECT convert (BIT, CASE @@ROWCOUNT
				WHEN 0 THEN 0
				ELSE 1
				END)