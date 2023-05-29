IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetUserDetails')
	DROP PROCEDURE GetUserDetails
GO

CREATE PROCEDURE GetUserDetails
	@userId varchar(20),	
	@password varchar(50)
AS
	SET NOCOUNT ON

	SELECT
		[Id],
		[UserId],
		[Password],
		[UserName],
		[Email],
		[UserRole],
		[AccountNumber],
		[MobileNumber],
		[IsActive]
	FROM
		[User]
	WHERE
	 [UserId] = @userId AND [Password] = @password
		
