IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActivateUser')
	DROP PROCEDURE ActivateUser
GO

CREATE PROCEDURE ActivateUser
	@userId varchar(20)
AS
	UPDATE [USER] SET [IsActive] = 1 WHERE UserId =  @userId;