CREATE PROCEDURE [dbo].[FindAccountsByName]
@accountname nvarchar(50)
AS
SELECT * FROM [dbo].[Accounts]
WHERE Name = @accountname