USE [TransactionDB]
GO

/****** Object:  StoredProcedure [dbo].[FundTransfer]    Script Date: 05-24-2023 17:32:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*Creating FUNDSTRANSFER Stored Procedure to transfer the money from one account to another account*/
CREATE PROCEDURE [dbo].[FundTransfer]
(
@SourceAcc varchar(50),
@DesAcc varchar(50),
@Amount decimal(18, 0)
)
AS
BEGIN

DECLARE @COUNT1 INT, @COUNT2 INT

BEGIN TRANSACTION

UPDATE AccountInformation SET CurrentBalance = CurrentBalance -@Amount WHERE AccountNo=@SourceAcc
SET @COUNT1=@@ROWCOUNT

UPDATE AccountInformation SET CurrentBalance = CurrentBalance +@Amount WHERE AccountNo=@DesAcc
SET @COUNT2=@@ROWCOUNT

IF @COUNT1=@COUNT2

BEGIN
COMMIT
PRINT 'AMOUNT HAS BEEN TRANFERRED'
SELECT * FROM AccountInformation WHERE AccountNo in(@SourceAcc, @DesAcc)
END

ELSE

BEGIN 
ROLLBACK
PRINT 'AMOUNT TRANFERED FAILED'
END
END
GO


