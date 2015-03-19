CREATE PROCEDURE [dbo].[FindAccountsByHouseHold] 
	@household uniqueidentifier
AS
SELECT * From [dbo].[Accounts]
WHERE HouseHold = @household