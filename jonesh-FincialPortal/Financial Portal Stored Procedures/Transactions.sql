USE [financial_portal_mock]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 3/10/2015 2:46:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[Id] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Amount] [nvarchar](50) NOT NULL,
	[AbsAmount] [nvarchar](50) NOT NULL,
	[ReconciledAmount] [nvarchar](50) NULL,
	[AbsREconciledAmount] [nvarchar](50) NULL,
	[Date] [datetimeoffset](7) NOT NULL,
	[Description] [nvarchar](128) NOT NULL,
	[Updated] [datetimeoffset](7) NULL,
	[UpdatedByUserId] [int] NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Accounts] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Accounts]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Categories]
GO

