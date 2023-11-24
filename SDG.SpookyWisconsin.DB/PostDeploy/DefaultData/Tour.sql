BEGIN
	DECLARE @HauntedLocationId1 uniqueidentifier
	SELECT @HauntedLocationId1 = Id FROM tblHauntedLocation WHERE Name = 'Forest Hill Cemetery'
	INSERT INTO tblTour (Id, HauntedLocationId, TourName, Description)
	VALUES
	(NEWID(), @HauntedLocationId1, 'Forest Hill Cemetery Tour', 'A guided tour through Forest Hill Cemetery')

	SELECT @HauntedLocationId1 = Id FROM tblHauntedLocation WHERE Name = 'Riverside Cemetery'
	INSERT INTO tblTour (Id, HauntedLocationId, TourName, Description)
	VALUES
	(NEWID(), @HauntedLocationId1, 'Riverside Cemetery Tour', 'A guided tour through Riverside Cemetery')

	SELECT @HauntedLocationId1 = Id FROM tblHauntedLocation WHERE Name = 'Al Ringling Mansion'
	INSERT INTO tblTour (Id, HauntedLocationId, TourName, Description)
	VALUES
	(NEWID(), @HauntedLocationId1, 'Al Ringling Mansion Haunted Tour', 'A paranormal tour through Al Ringling Mansion')

	SELECT @HauntedLocationId1 = Id FROM tblHauntedLocation WHERE Name = 'Old Baraboo Inn'
	INSERT INTO tblTour (Id, HauntedLocationId, TourName, Description)
	VALUES
	(NEWID(), @HauntedLocationId1, 'Night at the Old Baraboo Inn', 'A night tour in Old Baraboo Inn')
END