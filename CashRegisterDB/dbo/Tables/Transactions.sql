CREATE TABLE [dbo].[Transactions]
(	
	[Id]                INT             IDENTITY (1, 1) NOT NULL,
	[Quantity]			DECIMAL(7,3)	NOT NULL, 
    [Time]				DATETIME2		NOT NULL,	
	[ReceiptId]			INT				NOT NULL CONSTRAINT FK_Transactions_Receipts FOREIGN KEY ([ReceiptId]) REFERENCES [dbo].[Receipts] ([Id]),
	[ItemId]			INT				NOT NULL CONSTRAINT FK_Transactions_Items FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([Id]),
	
    PRIMARY KEY CLUSTERED ([Id] DESC)
)
