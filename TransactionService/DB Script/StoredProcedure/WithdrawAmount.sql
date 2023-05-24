USE [TransactionDB]
GO

/****** Object:  StoredProcedure [dbo].[WithdrawAmount]    Script Date: 05-24-2023 17:34:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[WithdrawAmount]
(
@Account varchar(50),
@Amount decimal(18, 0)
)
AS
BEGIN
UPDATE AccountInformation SET CurrentBalance = CurrentBalance -@Amount WHERE AccountNo=@Account
SELECT * FROM AccountInformation WHERE AccountNo = @Account
END
GO


