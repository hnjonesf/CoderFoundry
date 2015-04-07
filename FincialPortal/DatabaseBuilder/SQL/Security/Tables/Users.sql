﻿CREATE TABLE [Security].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HouseHold] uniqueidentifier NULL,
	[UserName] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NULL,
	[Email] [nvarchar](128) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[IsDeleted] bit not null default 0,
	[IsLockedOut] bit not null default 0,
	[PasswordResetToken] [nvarchar](128) NULL,
	[PasswordResetExpiry] datetimeoffset(7) NULL,
	[LockoutEndDate] datetimeoffset(7) NULL,
	[AccessFailedCount] int default 0 NOT NULL,
	[EmailConfirmed] bit default 0 NOT NULL,
	[LockoutEnabled] bit default 1 NOT NULL,
	[TwoFactorEnabled] bit default 0 NOT NULL,
	[PhoneNumberConfirmed] bit default 0 NOT NULL,
	[PhoneNumber] nvarchar(MAX)
	)
GO

ALTER TABLE [Security].[Users]
ADD CONSTRAINT [PK_Security.Users] PRIMARY KEY CLUSTERED ([Id] ASC )
GO

CREATE UNIQUE NONCLUSTERED INDEX IX_Users_Username 
    ON [Security].[Users] ( Username ) 
GO

AUTOPROC All [Security].[Users]
GO
