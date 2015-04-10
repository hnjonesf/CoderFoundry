CREATE PROCEDURE [dbo].[IsInvitation]
	@inviteEmail nvarchar(256)
AS
BEGIN
	SELECT CONVERT(bit, COUNT(inv.Id))
		FROM [dbo].[Invitations] AS inv
		WHERE inv.ToEmail = @inviteEmail
END
GO
