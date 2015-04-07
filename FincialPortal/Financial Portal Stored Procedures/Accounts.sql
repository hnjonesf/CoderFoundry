USE [financial_portal_mock]
GO

/****** Object:  Table [dbo].[Accounts]    Script Date: 3/10/2015 2:46:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accounts](
	[Id] [int] NOT NULL,
	[HouseHold] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Balance] [decimal](18, 0) NULL,
	[ReconciledBalance] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

