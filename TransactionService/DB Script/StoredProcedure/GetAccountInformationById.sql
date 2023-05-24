USE [TransactionDB]
GO

/****** Object:  StoredProcedure [dbo].[GetAccountInformationById]    Script Date: 05-24-2023 17:33:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAccountInformationById]
       -- Add the parameters for the stored procedure here
       --@Id uniqueidentifier,
       @AccountNo varchar(50)
       
AS
BEGIN

    -- Select statements for procedure here
       SELECT AccountNo, Name, CurrentBalance FROM AccountInformation WHERE AccountNo = @AccountNo
              
END
GO


