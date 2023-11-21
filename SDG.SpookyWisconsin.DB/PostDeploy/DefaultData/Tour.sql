BEGIN
	DECLARE @HauntedLocationId uniqueidentifier
	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Forest Hill Cemetery'
	INSERT INTO tblTour (Id, HauntedLocationId, TourName, Description)
	VALUES
	(NEWID(), @HauntedLocationId, 'Forest Hill Cemetery Tour', 'A guided tour through Forest Hill Cemetery')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Riverside Cemetery'
	INSERT INTO tblTour (Id, HauntedLocationId, TourName, Description)
	VALUES
	(NEWID(), @HauntedLocationId, 'Riverside Cemetery Tour', 'A guided tour through Riverside Cemetery')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Al Ringling Mansion'
	INSERT INTO tblTour (Id, HauntedLocationId, TourName, Description)
	VALUES
	(NEWID(), @HauntedLocationId, 'Al Ringling Mansion Haunted Tour', 'A paranormal tour through Al Ringling Mansion')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Old Baraboo Inn'
	INSERT INTO tblTour (Id, HauntedLocationId, TourName, Description)
	VALUES
	(NEWID(), @HauntedLocationId, 'Night at the Old Baraboo Inn', 'A night tour in Old Baraboo Inn')
END