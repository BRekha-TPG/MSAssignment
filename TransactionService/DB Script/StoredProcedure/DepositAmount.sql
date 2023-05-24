USE [TransactionDB]
GO

/****** Object:  StoredProcedure [dbo].[DepositAmount]    Script Date: 05-24-2023 17:31:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*Creating DepositAmount Stored Procedure to */
CREATE PROCEDURE [dbo].[DepositAmount]
(
@Account varchar(50),
@Amount decimal(18, 0)
)
AS
BEGIN
UPDATE AccountInformation SET CurrentBalance = CurrentBalance +@Amount WHERE AccountNo=@Account
SELECT * FROM AccountInformation WHERE AccountNo = @Account
END


GO


