CREATE PROCEDURE [dbo].[GetRecentTransByHousehold]
	@householdId int
AS
BEGIN
	SELECT TOP 5 CONVERT(varchar(10),[dbo].AccountTransactions.[Date],101) AS Date
		, [dbo].Categories.[Name] AS Category
		, [Security].Users.[Name] AS [User]
		, [dbo].AccountTransactions.[SignedAmount] AS [Amount]
		, [dbo].AccountTransactions.[Description]
		, [dbo].Accounts.[Name] AS [Account]
	FROM [dbo].AccountTransactions 
		INNER JOIN [Security].Users
			ON AccountTransactions.UpdatedByUserId=[Security].Users.Id
		INNER JOIN Categories
			ON AccountTransactions.CategoryId=Categories.Id
		INNER JOIN Accounts
			ON AccountTransactions.AccountId=Accounts.Id
	WHERE [dbo].[Account].HouseHold = @householdId
	ORDER BY [dbo].AccountTransactions.[Date] DESC, [dbo].AccountTransactions.[Id] DESC
END
GO
