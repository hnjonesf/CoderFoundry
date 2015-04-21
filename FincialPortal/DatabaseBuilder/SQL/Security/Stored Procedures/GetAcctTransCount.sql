CREATE PROCEDURE [dbo].[GetAcctTransCount]
	@accountId INT
AS
BEGIN
	SELECT COUNT(Id)
	FROM AccountTransactions
	WHERE AccountId = @accountId
END
GO