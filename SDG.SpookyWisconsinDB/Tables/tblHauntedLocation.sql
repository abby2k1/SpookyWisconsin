CREATE TABLE [dbo].[tblHauntedLocation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AddressId] INT NOT NULL, 
    [CountyId] INT NOT NULL, 
    [Name] VARCHAR(100) NOT NULL
)
