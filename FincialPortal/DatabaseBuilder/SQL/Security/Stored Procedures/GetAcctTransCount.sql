CREATE PROCEDURE [dbo].[GetAcctTransCount]
	@accountId INT
AS
BEGIN
	SELECT COUNT(Id)
	FROM Transactions
	WHERE AccountId = @accountId
END
GO