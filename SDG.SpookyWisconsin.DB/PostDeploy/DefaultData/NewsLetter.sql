BEGIN
	INSERT INTO tblNewsLetter (Id, HauntedEventId, Description, Date)
	VALUES
	(NEWID(), 1, 'Veteran Walk-Through in Forest Hill Cemetery', '10-01-2023'),
	(NEWID(), 2, 'Kate Blood Gravestone Story Time', '10-15-2023'),
	(NEWID(), 3, 'Keeping Up with the Circus', '10-22-2023'),
	(NEWID(), 4, 'Stay the Night for a Fright', '11-10-2023')
END