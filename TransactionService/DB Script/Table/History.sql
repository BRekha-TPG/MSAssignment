USE [TransactionDB]
GO

/****** Object:  Table [dbo].[History]    Script Date: 05-24-2023 17:28:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[History](
	[Id] [uniqueidentifier] NOT NULL,
	[AccountNo] [varchar](50) NOT NULL,
	[TransactionType] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[TransactionNo] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


