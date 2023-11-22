CREATE TABLE [dbo].[tblMerch]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [MerchName] VARCHAR(255) NOT NULL, 
    [InStkQty] INT NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [Cost] DEC NOT NULL,
    [ImagePath] NVARCHAR(255) NOT NULL
)
