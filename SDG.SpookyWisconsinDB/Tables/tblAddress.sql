CREATE TABLE [dbo].[tblAddress]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Street] VARCHAR(50) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [County] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(2) NOT NULL, 
    [ZIP] VARCHAR(5) NOT NULL
)
