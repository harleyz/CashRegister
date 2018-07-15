CREATE TABLE [dbo].[Items]
(
	[Id]                  INT              IDENTITY (1, 1) NOT NULL,
    [SKU]		          UNIQUEIDENTIFIER NOT NULL,
    [ProductName]         NVARCHAR (255)   NOT NULL,
    [Cost]				  MONEY NOT NULL, 
    [UnitOfMeasure]	      INT NOT NULL, 
    [QuanityOfMeasure]	  DECIMAL NOT NULL, 

    PRIMARY KEY CLUSTERED ([Id] DESC)
)
