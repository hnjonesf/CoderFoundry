
CREATE TABLE [dbo].[AccountTransactions](
	[Id] [int] IDENTITY NOT NULL,
	[AccountId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[AbsAmount] [decimal](18, 2) NOT NULL,
	[ReconciledAmount] [decimal](18, 2) NOT NULL,
	[AbsREconciledAmount] [decimal](18, 2) NOT NULL,
	[Date] [datetimeoffset](7) NOT NULL,
	[Description] [nvarchar](128) NOT NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedByUserId] [int] NULL,
	[CategoryId] [int] NOT NULL
	)
	GO

		ALTER TABLE [dbo].[AccountTransactions]

ADD CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)

GO


ALTER TABLE [dbo].[AccountTransactions]  
WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users] 
FOREIGN KEY([UpdatedByUserId])
REFERENCES [Security].[Users] ([Id])
GO

ALTER TABLE [dbo].[AccountTransactions] 
CHECK CONSTRAINT [FK_Transactions_Users]
GO


ALTER TABLE [dbo].[AccountTransactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO

ALTER TABLE [dbo].[AccountTransactions] CHECK CONSTRAINT [FK_Transactions_Accounts]
GO

ALTER TABLE [dbo].[AccountTransactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO

ALTER TABLE [dbo].[AccountTransactions] CHECK CONSTRAINT [FK_Transactions_Categories]
GO

AUTOPROC All [dbo].[AccountTransactions]
GO