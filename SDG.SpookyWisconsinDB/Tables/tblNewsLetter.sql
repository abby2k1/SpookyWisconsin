CREATE TABLE [dbo].[tblNewsLetter]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [HauntedEventID] INT NOT NULL, 
    [Description] VARCHAR(250) NOT NULL, 
    [Date] DATE NOT NULL
)
