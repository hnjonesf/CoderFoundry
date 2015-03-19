CREATE PROCEDURE [dbo].[FindTransactionsByUserId] 
	@userid int
AS
SELECT * From [dbo].[Transactions]
WHERE UpdatedByUserId = @userid