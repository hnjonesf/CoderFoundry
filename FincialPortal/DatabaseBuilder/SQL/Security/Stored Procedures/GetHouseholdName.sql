CREATE PROCEDURE [Security].[GetHouseholdName]
	@householdId int
AS
BEGIN
	SELECT [Name] FROM [Security].[Households]
	WHERE Id = @householdId
END
GO