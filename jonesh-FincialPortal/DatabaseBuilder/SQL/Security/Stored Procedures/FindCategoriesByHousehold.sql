CREATE PROCEDURE [dbo].[FindCategoriesByHousehold] 
	@category nvarchar(50)
AS
SELECT * From [dbo].[Categories]
WHERE Name = @category