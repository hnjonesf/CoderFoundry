CREATE PROCEDURE [dbo].[FindAccountTransactionsByUserId] 
	@userid int
AS
SELECT * From [dbo].[AccountTransactions]
WHERE UpdatedByUserId = @userid