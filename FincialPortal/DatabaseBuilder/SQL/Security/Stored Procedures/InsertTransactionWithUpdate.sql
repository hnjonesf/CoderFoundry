CREATE PROCEDURE [dbo].[InsertTransaction]
(
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

INSERT INTO [dbo].[Transactions]
(
	[AccountId],
	[Amount],
	[Date],
	[Description],
	[Updated],
	[UpdatedByUserId],
	[CategoryId],
	[Reconciled],
	[HouseholdId],
	[SignedAmount]
)
OUTPUT
	Inserted.[Id]
INTO @T
VALUES
(
	@AccountId,
	@Amount,
	@Date,
	@Description,
	@Updated,
	@UpdatedByUserId,
	@CategoryId,
	@Reconciled,
	@HouseholdId,
	@SignedAmount
)
SELECT * FROM @T

DECLARE @accId int
SET @accId = @AccountId
EXEC [dbo].[UpdateAccountBalances] @accId
GO

