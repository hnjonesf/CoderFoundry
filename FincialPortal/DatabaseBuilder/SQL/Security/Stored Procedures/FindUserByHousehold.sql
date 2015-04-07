CREATE PROCEDURE [Security].[FindUserByHousehold] 
	@household uniqueidentifier
AS
SELECT * From [Security].[Users]
WHERE HouseHold = @household