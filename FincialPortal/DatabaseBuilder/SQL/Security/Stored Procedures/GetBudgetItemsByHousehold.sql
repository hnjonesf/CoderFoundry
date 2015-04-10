CREATE PROCEDURE [dbo].[GetBudgetItemsByHousehold]
	@householdId int,
	@expense int
AS
BEGIN
	SELECT [dbo].[BudgetItems].[Id]
		  ,[dbo].[BudgetItems].[HouseholdId]
		  ,[dbo].[BudgetItems].[Expense]
		  ,[dbo].[BudgetItems].[CategoryId]
		  ,[dbo].[Categories].Name AS Category
		  ,[dbo].[BudgetItems].[Amount]
		  ,[dbo].[BudgetItems].[Period]
		  ,([dbo].[BudgetItems].[Amount] * [dbo].[BudgetItems].[Period] / 12) AS Monthly
		  ,[dbo].[BudgetItems].[Description] 
	FROM [dbo].[BudgetItems] 
		INNER JOIN [dbo].[Categories]
			ON [CategoryId]=[Categories].Id
	WHERE [dbo].[BudgetItems].[HouseholdId] = @householdId AND [dbo].[BudgetItems].[Expense] = @expense
	ORDER BY [dbo].[BudgetItems].[CategoryId] ASC
END
GO
