
CREATE TABLE [dbo].[Invitations](
	[Id] [int] IDENTITY NOT NULL,
	[FromUserId] [int] NULL,
	[ToEmail] [nchar](50) NULL
	)
	GO

		ALTER TABLE [dbo].[Invitations]


ADD CONSTRAINT [PK_Invitations] PRIMARY KEY CLUSTERED 

(
	[Id] ASC
)

GO

AUTOPROC All [dbo].[Invitations]
GO