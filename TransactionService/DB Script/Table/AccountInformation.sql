USE [TransactionDB]
GO

/****** Object:  Table [dbo].[AccountInformation]    Script Date: 05-25-2023 18:20:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AccountInformation](
	[Id] [int] IDENTITY NOT NULL,
	[AccountNo] [varchar](50) NOT NULL,
	[Address] [varchar](50) NULL,
	[CurrentBalance] [decimal](18, 0) NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_AccountInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


