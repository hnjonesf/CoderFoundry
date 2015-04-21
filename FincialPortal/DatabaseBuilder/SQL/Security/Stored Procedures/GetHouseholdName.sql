CREATE PROCEDURE [Security].[GetHouseholdName]
	@householdId uniqueidentifier
AS
BEGIN
	SELECT [Name] FROM [Security].[HouseHolds]
	WHERE Id = @householdId
END
GO