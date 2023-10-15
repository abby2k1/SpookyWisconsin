BEGIN
	INSERT INTO tblHauntedEvent (Id, HauntedLocationId, ParticipantId, Date, Description)
	VALUES
	(NEWID(), 4, 1, '10-31-2023', 'Veteran Walk-Through in Forest Hill Cemetery'),
	(NEWID(), 15, 2, '11-05-2023', 'Kate Blood Gravestone Story Time'),
	(NEWID(), 18, 3, '11-16-2023', 'Keeping Up with the Circus'),
	(NEWID(), 19, 4, '12-04-2023', 'Stay the Night for a Fright')
END