CREATE TABLE [dbo].[DiscountTransactions]
(	
	[Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Time]				DATETIME2		NOT NULL,	
	[ReceiptId]			INT				NOT NULL CONSTRAINT FK_DiscountTransactions_Receipts FOREIGN KEY ([ReceiptId]) REFERENCES [dbo].[Receipts] ([Id]),	
	[DiscountId]		INT				NOT NULL CONSTRAINT FK_DiscountTransactions_Discount FOREIGN KEY ([DiscountId]) REFERENCES [dbo].[Discounts] ([Id]),
	[ItemId]			INT				NULL CONSTRAINT FK_DiscountTransactions_Items FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([Id])
	
    PRIMARY KEY CLUSTERED ([Id] DESC)
)
