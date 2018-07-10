CREATE TABLE [dbo].[Transactions]
(
	[Id]				INT				NOT NULL PRIMARY KEY, 
    [Item]				INT				NOT NULL,
	[Quantity]			DECIMAL(7,3)	NOT NULL, 
    [Time]				DATETIME2		NOT NULL,	
	[ItemId]			INT				NOT NULL CONSTRAINT FK_Transactoins_Items FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([Id]),
)
