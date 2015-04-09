CREATE PROCEDURE [dbo].[GetAccountBalance] 
	@accountId int
AS
SELECT (Sum(t.Amount)+a.Balance) From [dbo].[Accounts]
Accounts a 
Join 
AccountTransactions t 
on 
a.Id = t.AccountId
WHERE AccountId = @accountId
