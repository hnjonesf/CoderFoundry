CREATE PROCEDURE [dbo].[GetBudgetStatus]
	@householdId int
AS
BEGIN
	DECLARE @CM INT, @LM INT
	SET @CM = MONTH(GETDATE())
	SET @LM = @CM-1
	IF @LM = 0 
		SET @LM = 12

	SELECT Categories.Id
			,Categories.Name AS Category
			,ISNULL((SELECT SUM(BudgetItems.Amount) 
				FROM BudgetItems 
					WHERE Categories.Id = BudgetItems.CategoryId ),0) AS Budgeted
			,ISNULL((SELECT ABS(SUM(Transactions.SignedAmount))
				FROM Transactions
					WHERE Categories.Id = Transactions.CategoryId
					AND MONTH(Transactions.[Date]) = @CM),0) AS "Current"
			,ISNULL((SELECT ABS(SUM(Transactions.SignedAmount))
				FROM Transactions
					WHERE Categories.Id = Transactions.CategoryId
					AND MONTH(Transactions.[Date]) = @LM),0) AS "Previous"
	FROM Categories 
	WHERE Categories.HouseholdId=@householdId
	ORDER BY Categories.Name
END
GO