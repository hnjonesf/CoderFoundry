CREATE PROCEDURE [dbo].[GetCategoriesByHousehold] 
@household uniqueidentifier
AS
SELECT * From [dbo].[Categories]
WHERE HouseHold = @household