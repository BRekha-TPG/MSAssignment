USE [TransactionDB]
GO

/****** Object:  StoredProcedure [dbo].[InsertAccountInformation]    Script Date: 05-24-2023 17:34:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertAccountInformation]
       -- Add the parameters for the stored procedure here
       
       @AccountNo varchar(50),
       @Address varchar(50),
       @CurrentBalance decimal(18,0),
	   @Name varchar(50)
AS
BEGIN
       -- SET NOCOUNT ON added to prevent extra result sets from
       -- interfering with SELECT statements.
       SET NOCOUNT ON;

    -- Insert statements for procedure here
       INSERT INTO AccountInformation
              (Id, AccountNo, Address, CurrentBalance, Name)
       VALUES
              (newid(), @AccountNo, @Address, @CurrentBalance, @Name)
END
GO


