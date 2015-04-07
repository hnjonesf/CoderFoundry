USE [financial_portal_mock]
GO

/****** Object:  Table [dbo].[Invitations]    Script Date: 3/10/2015 2:46:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Invitations](
	[Id] [int] NOT NULL,
	[FromUserId] [int] NULL,
	[ToEmail] [nchar](50) NULL,
 CONSTRAINT [PK_Invitations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

