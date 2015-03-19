
CREATE TABLE [dbo].[BudgetItems](
	[Id] [int] IDENTITY NOT NULL,
	[HouseHold] uniqueidentifier NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Amount] [decimal](18,2) NOT NULL
	)
	GO

	ALTER TABLE [dbo].[BudgetItems]

ADD CONSTRAINT [PK_BudgetItems] PRIMARY KEY CLUSTERED 

(
	[Id] ASC
)

GO

ALTER TABLE [dbo].[BudgetItems]  WITH CHECK ADD  CONSTRAINT [FK_BudgetItems_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])

GO

ALTER TABLE [dbo].[BudgetItems] CHECK CONSTRAINT [FK_BudgetItems_Categories]
GO

AUTOPROC All [dbo].[BudgetItems]
GO