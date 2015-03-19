CREATE PROCEDURE [dbo].[FindTransactionsByAccount] 
	@account int
AS
SELECT * From [dbo].[Transactions]
WHERE AccountId = @account