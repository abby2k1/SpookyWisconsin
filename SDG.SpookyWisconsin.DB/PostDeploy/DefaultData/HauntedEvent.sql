BEGIN
	DECLARE @HauntedLocationId uniqueidentifier
	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Forest Hill Cemetery'
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), @HauntedLocationId, 'Veteran Walk-Through in Forest Hill Cemetery', '10-31-2023', 'Veteran Walk-Through in Forest Hill Cemetery', 'image')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Riverside Cemetery'
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), @HauntedLocationId, 'Kate Blood Gravestone Story Time', '11-05-2023', 'Kate Blood Gravestone Story Time', 'image')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Al Ringling Mansion'
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), @HauntedLocationId, 'Keeping Up with the Circus', '11-16-2023', 'Keeping Up with the Circus', 'image')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Old Baraboo Inn'
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), @HauntedLocationId, 'Stay the Night for a Fright', '12-04-2023', 'Stay the Night for a Fright', 'image')
END