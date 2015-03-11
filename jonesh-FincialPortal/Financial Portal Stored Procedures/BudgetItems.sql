USE [financial_portal_mock]
GO

/****** Object:  Table [dbo].[BudgetItems]    Script Date: 3/10/2015 2:46:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BudgetItems](
	[Id] [int] NOT NULL,
	[HouseHold] [nvarchar](50) NULL,
	[CategoryId] [int] NOT NULL,
	[Amount] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BudgetItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BudgetItems]  WITH CHECK ADD  CONSTRAINT [FK_BudgetItems_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO

ALTER TABLE [dbo].[BudgetItems] CHECK CONSTRAINT [FK_BudgetItems_Categories]
GO

