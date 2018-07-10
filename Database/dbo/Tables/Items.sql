CREATE TABLE [dbo].[Items]
(
	[Id]                  INT              IDENTITY (1, 1) NOT NULL,
    [SKU]		          UNIQUEIDENTIFIER NOT NULL,
    [ProductName]         NVARCHAR (255)   NULL,
    [Cost]				  MONEY NULL, 
    [UnitOfMeasure]	      INT NULL, 
    [QuanityOfMeasure]	  DECIMAL NULL, 
    PRIMARY KEY CLUSTERED ([Id] DESC),
)
