CREATE TABLE [dbo].[tblCart]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [MerchId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [TotalCost] FLOAT NOT NULL
)
