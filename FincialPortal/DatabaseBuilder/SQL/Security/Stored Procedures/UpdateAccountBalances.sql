CREATE PROCEDURE [dbo].[UpdateAccountBalances]
	@accId int
AS
BEGIN
	UPDATE [dbo].[Accounts]
	SET ReconciledBalance = 
			(SELECT SUM(SignedAmount) FROM [dbo].Transactions
			WHERE AccountId = @accId AND Reconciled = 1),
		Balance = 
			(SELECT SUM(SignedAmount) FROM [dbo].Transactions
			WHERE AccountId = @accId)
	WHERE Id = @accId
END
GO