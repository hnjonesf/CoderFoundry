CREATE PROCEDURE [dbo].[GetAccountTransactionsForAccount] 
	@accountid int
AS
SELECT * From [dbo].[AccountTransactions]
WHERE AccountId = @accountid