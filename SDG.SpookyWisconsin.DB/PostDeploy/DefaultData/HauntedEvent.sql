BEGIN
	DECLARE @HauntedLocationId uniqueidentifier
	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Forest Hill Cemetery'
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), @HauntedLocationId, 'Veteran Walk-Through in Forest Hill Cemetery', '10-31-2024', 'Veteran Walk-Through in Forest Hill Cemetery', 'foresthill2.png')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Riverside Cemetery'
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), @HauntedLocationId, 'Kate Blood Gravestone Story Time', '11-05-2024', 'Kate Blood Gravestone Story Time', 'riversidecemetery2.png')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Al Ringling Mansion'
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), @HauntedLocationId, 'Keeping Up with the Circus', '11-16-2024', 'Keeping Up with the Circus', 'alringling1.png')

	SELECT @HauntedLocationId = Id FROM tblHauntedLocation WHERE Name = 'Old Baraboo Inn'
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), @HauntedLocationId, 'Stay the Night for a Fright', '12-04-2024', 'Stay the Night for a Fright', 'oldbaraboo1.png')
END