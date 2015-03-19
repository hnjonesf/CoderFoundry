CREATE PROCEDURE [dbo].[FindTransactionsByAccount] 
	@accountid int
AS
SELECT * From [dbo].[Transactions]
WHERE AccountId = @accountid