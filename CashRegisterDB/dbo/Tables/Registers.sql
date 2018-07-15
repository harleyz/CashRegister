CREATE TABLE [dbo].[Registers]
(	
	[Id]        INT             IDENTITY (1, 1) NOT NULL, 
    [Name]		NVARCHAR (100)	NOT NULL, 
    [Location]	NVARCHAR (100)	NOT NULL,
	
    PRIMARY KEY CLUSTERED ([Id] DESC)
)
