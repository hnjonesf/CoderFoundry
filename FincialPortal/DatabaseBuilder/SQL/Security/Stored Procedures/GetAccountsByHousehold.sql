CREATE PROCEDURE [dbo].[GetAccountsByHousehold]
	@householdId int
AS
BEGIN
	SELECT * FROM [dbo].[Accounts]
	WHERE [dbo].[Accounts].HouseholdId = @householdId
END
GO