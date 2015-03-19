CREATE PROCEDURE [Security].[FindUserByHousehold] 
	@household nvarchar(128)
AS
SELECT * From [Security].[Users]
WHERE Household = @household