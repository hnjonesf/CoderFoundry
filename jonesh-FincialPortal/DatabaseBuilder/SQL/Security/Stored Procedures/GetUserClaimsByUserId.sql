USE [cf_jonesh_userstore_db]
GO

/****** Object:  StoredProcedure [Security].[GetUserLoginsByUserId]    Script Date: 3/12/2015 1:15:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Security].[GetUserLoginsByUserId]
@userId int AS
SELECT r.[Name]
FROM [Security].[Roles] r JOIN
[Security].[UserRoles] ur
ON r.[Id] = ur.[RoleId]
WHERE ur.UserId = @userId
GO

