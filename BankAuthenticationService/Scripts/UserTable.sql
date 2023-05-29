USE [BankAuthentication]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'User')
BEGIN
CREATE TABLE [User]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[UserId] VARCHAR(20) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[UserRole] [smallint] NOT NULL,
	[AccountNumber] [INT] NOT NULL,
	[MobileNumber] [varchar](10) NULL,
	[IsActive] [BIT] Default 0,
	
	 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
END

