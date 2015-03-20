
CREATE TABLE [dbo].[Budgets](
	[Id] [int] IDENTITY NOT NULL,
	[HouseHold] uniqueidentifier NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Amount] [decimal](18,2) NOT NULL
	)
	GO

	ALTER TABLE [dbo].[Budgets]

ADD CONSTRAINT [PK_Budgets] PRIMARY KEY CLUSTERED 

(
	[Id] ASC
)

GO

ALTER TABLE [dbo].[Budgets]  WITH CHECK ADD  CONSTRAINT [FK_Budgets_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])

GO

ALTER TABLE [dbo].[Budgets] CHECK CONSTRAINT [FK_Budgets_Categories]
GO

AUTOPROC All [dbo].[Budgets]
GO