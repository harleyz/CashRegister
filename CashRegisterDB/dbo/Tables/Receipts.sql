CREATE TABLE [dbo].[Receipts]
(
	[Id]                INT             IDENTITY (1, 1) NOT NULL,
	[RegisterId]		INT				NOT NULL CONSTRAINT FK_Receipts_Transactions FOREIGN KEY ([RegisterId]) REFERENCES [dbo].[Registers] ([Id]),	
    [Time]				DATETIME2		NOT NULL,	

    PRIMARY KEY CLUSTERED ([Id] DESC)
)
