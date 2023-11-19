BEGIN
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, ParticipantId,Name, Date, Description, ImagePath)
	VALUES
	(NEWID(), 4, 1, 'Veteran Walk-Through in Forest Hill Cemetery', '10-31-2023', 'Veteran Walk-Through in Forest Hill Cemetery', 'image'),
	(NEWID(), 15, 2, 'Kate Blood Gravestone Story Time', '11-05-2023', 'Kate Blood Gravestone Story Time', 'image'),
	(NEWID(), 18, 3, 'Keeping Up with the Circus', '11-16-2023', 'Keeping Up with the Circus', 'image'),
	(NEWID(), 19, 4, 'Stay the Night for a Fright', '12-04-2023', 'Stay the Night for a Fright', 'image')
END