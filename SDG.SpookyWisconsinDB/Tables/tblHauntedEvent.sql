CREATE TABLE [dbo].[tblHauntedEvent]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [HauntedLocationId] INT NOT NULL, 
    [ParticipantId] INT NOT NULL, 
    [Date] DATE NOT NULL, 
    [Description] VARCHAR(250) NOT NULL
)
