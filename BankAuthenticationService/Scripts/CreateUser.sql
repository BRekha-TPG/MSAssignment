IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CreateUser')
	DROP PROCEDURE CreateUser
GO

CREATE PROCEDURE CreateUser
	@userId varchar(20),
	@userName VARCHAR(50),
	@password VARCHAR(50),
	@email VARCHAR(50),
	@userRole smallint,
	@accountNumber VARCHAR(20),
	@mobileNumber VARCHAR(10),
	@isActive Bit
AS
	INSERT INTO [User](
		[UserId],
		[UserName],
		[Password],
		[Email],
		[UserRole],
		[AccountNumber],
		[MobileNumber],
		[IsActive])
	VALUES(
		@userId,
		@userName,
		@password,
		@email,
		@userRole,
		@accountNumber,
		@mobileNumber,
		@isActive)
