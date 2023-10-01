CREATE TABLE [dbo].[tblNewsLetter]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [HauntedEventId] INT NOT NULL, 
    [Description] VARCHAR(250) NOT NULL, 
    [Date] DATE NOT NULL
)
