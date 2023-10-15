CREATE TABLE [dbo].[tblMerch]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [MerchName] VARCHAR(50) NOT NULL, 
    [InStkQty] INT NOT NULL, 
    [Description] VARCHAR(50) NOT NULL, 
    [Cost] FLOAT NOT NULL
)
