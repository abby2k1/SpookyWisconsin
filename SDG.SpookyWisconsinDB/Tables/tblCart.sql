CREATE TABLE [dbo].[tblCart]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [MerchId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [TotalCost] FLOAT NOT NULL
)
