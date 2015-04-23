CREATE FUNCTION [dbo].[FnGetTransSumByCatPeriod]
(
	@catId int,
	@period int
)
RETURNS money
AS
BEGIN
	DECLARE @Total money
	SET @Total = (SELECT SUM(Transactions.SignedAmount)
	FROM AccountTransactions 
	WHERE CategoryId = @catId 
		AND DATEDIFF(day,[Date],GETDATE()) < @period)
	RETURN @Total
END
GO

CREATE PROCEDURE [dbo].[GetTransSumByCatPeriod]
	@householdId int,
	@period int
AS
BEGIN
	SELECT	*,
			(SELECT  COUNT([dbo].[Transactions].Id)
				FROM [dbo].[Transactions]
				WHERE [dbo].[Categories].Id = CategoryId ) AS [Count], 
			[dbo].[FnGetTransSumByCatPeriod](Id, @period) AS Total

	FROM  [dbo].[Categories]  
	WHERE householdId = @householdId 


	
END
GO