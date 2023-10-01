CREATE TABLE [dbo].[tblOrder]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [InCartId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [OrderDate] DATE NOT NULL, 
    [DeliverDate] DATE NOT NULL
)
