﻿CREATE TABLE [Security].[UserClaims](
	[Id] INT IDENTITY NOT NULL,
	[UserId] int NOT NULL,
	[ClaimType] nvarchar(max) NOT NULL,
	[ClaimValue] nvarchar(max) NOT NULL
)
GO

ALTER TABLE [Security].[UserClaims]
ADD CONSTRAINT [PK_Security.UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
GO

ALTER TABLE [Security].[UserClaims]  
WITH CHECK ADD  CONSTRAINT [FK_Security.UserClaims_Security.Users_UserId] 
FOREIGN KEY([UserId])
REFERENCES [Security].[Users] ([Id])
GO

AUTOPROC Insert [Security].[UserClaims]
GO