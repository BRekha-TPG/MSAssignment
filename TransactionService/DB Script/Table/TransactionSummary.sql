USE [TransactionDB]
GO

/****** Object:  Table [dbo].[TransactionSummary]    Script Date: 05-24-2023 17:29:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionSummary](
	[AccountId] [uniqueidentifier] NOT NULL,
	[FromAccount] [varchar](50) NULL,
	[ToAccount] [varchar](50) NULL,
	[TransactionType] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[StatusMessage] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TransactionSummary] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TransactionSummary]  WITH CHECK ADD  CONSTRAINT [FK_TransactionSummary_AccountInformation] FOREIGN KEY([AccountId])
REFERENCES [dbo].[AccountInformation] ([Id])
GO

ALTER TABLE [dbo].[TransactionSummary] CHECK CONSTRAINT [FK_TransactionSummary_AccountInformation]
GO


