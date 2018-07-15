CREATE TABLE [dbo].[Discounts]
(
	[Id]                INT					IDENTITY (1, 1) NOT NULL,
    [Code]		        NVARCHAR (15)		NOT NULL,
    [SKU]		        UNIQUEIDENTIFIER	NOT NULL,
	[Percent]			INT					NULL,
	[BuyX]				INT					NULL,
	[FreeY]				INT					NULL,
	[ItemId]			INT					NULL CONSTRAINT FK_Discounts_Items FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([Id])

	
    PRIMARY KEY CLUSTERED ([Id] DESC),	
)
