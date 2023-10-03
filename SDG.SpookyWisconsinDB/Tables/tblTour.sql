CREATE TABLE [dbo].[tblTour]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [HauntedLocationId] INT NOT NULL, 
    [TourName] VARCHAR(100) NOT NULL, 
    [Description] VARCHAR(50) NOT NULL
)
