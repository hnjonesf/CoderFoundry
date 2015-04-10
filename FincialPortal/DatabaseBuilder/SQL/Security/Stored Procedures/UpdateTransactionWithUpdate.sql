CREATE PROCEDURE [dbo].[UpdateTransactionWithUpdate]
(
	@Id int,
	@AccountId int,
	@Amount money,
	@Date datetimeoffset,
	@Description nvarchar(MAX) = NULL,
	@Updated datetimeoffset,
	@UpdatedByUserId int,
	@CategoryId int,
	@Reconciled bit,
	@HouseholdId int,
	@SignedAmount money = NULL
)
AS
DECLARE @T TABLE(
[Id] int)

UPDATE [dbo].[Transactions] SET
	[AccountId]=@AccountId,
	[Amount]=@Amount,
	[Date]=@Date,
	[Description]=@Description,
	[Updated]=@Updated,
	[UpdatedByUserId]=@UpdatedByUserId,
	[CategoryId]=@CategoryId,
	[Reconciled]=@Reconciled,
	[HouseholdId]=@HouseholdId,
	[SignedAmount]=@SignedAmount
OUTPUT
	Inserted.[Id]
INTO @T
WHERE
	[Id]=@Id
SELECT * FROM @T

DECLARE @accId int
SET @accId = @AccountId
EXEC [dbo].[UpdateAccountBalances] @accId
GO


