CREATE PROCEDURE [dbo].[FindCategoriesByHousehold] 
@household uniqueidentifier
AS
SELECT * From [dbo].[Categories]
WHERE HouseHold = @household