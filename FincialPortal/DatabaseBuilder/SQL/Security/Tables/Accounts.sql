
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY NOT NULL,
	[HouseHold] uniqueidentifier NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Balance] [decimal](18, 2) NULL,
	[ReconciledBalance] [decimal](18, 2) NULL
	)
	GO

	ALTER TABLE [dbo].[Accounts]

ADD CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 

(
	[Id] ASC
)

GO

AUTOPROC All [dbo].[Accounts]
GO

