CREATE PROCEDURE [dbo].[GetAcctTransactions]
	@accountId int,
	@rowoffset int,
	@numrows int
AS
BEGIN
	SELECT [Transactions].[Id]
      ,[AccountId]
      ,[Amount]
      ,CONVERT(varchar(10),[dbo].Transactions.[Date],101) AS TransDate
      ,[Description]
      ,CONVERT(varchar(10),[dbo].Transactions.[Updated],101) As Updated
      ,[UpdatedByUserId]
      ,[CategoryId]
      ,[Reconciled]
      ,[Transactions].[HouseholdId]
      ,[SignedAmount]
	  ,[Categories].[Name] AS Category
	  ,[Security].[Users].[Name] AS UpdatedByUser
	FROM Transactions 
		INNER JOIN Categories ON  [Categories].Id = CategoryId
		INNER JOIN [Security].[Users] ON [Security].[Users].Id = UpdatedByUserId
	WHERE AccountId = @accountId
	ORDER BY Id DESC
		OFFSET @rowoffset ROWS 
		FETCH NEXT @numrows ROWS ONLY;
END
GO