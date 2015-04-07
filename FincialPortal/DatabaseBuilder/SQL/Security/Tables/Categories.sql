
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY NOT NULL,
	[HouseHold] uniqueidentifier NOT NULL,
	[Name] [nvarchar](50) NULL
	)
	GO

	ALTER TABLE [dbo].[Categories]

ADD CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)

GO

AUTOPROC All [dbo].[Categories]
GO