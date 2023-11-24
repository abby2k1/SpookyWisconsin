BEGIN
	DECLARE @EventId1 uniqueidentifier
	SELECT @EventId1 = Id FROM tblHauntedEvent WHERE Name = 'Veteran Walk-Through in Forest Hill Cemetery'
	INSERT INTO tblNewsLetter (Id, HauntedEventId, Description, Date)
	VALUES
	(NEWID(), @EventId1, 'Veteran Walk-Through in Forest Hill Cemetery', '10-01-2023')
	
	SELECT @EventId1 = Id FROM tblHauntedEvent WHERE Name = 'Kate Blood Gravestone Story Time'
	INSERT INTO tblNewsLetter (Id, HauntedEventId, Description, Date)
	VALUES
	(NEWID(), @EventId1, 'Kate Blood Gravestone Story Time', '10-15-2023')
	
	SELECT @EventId1 = Id FROM tblHauntedEvent WHERE Name = 'Keeping Up with the Circus'
	INSERT INTO tblNewsLetter (Id, HauntedEventId, Description, Date)
	VALUES
	(NEWID(), @EventId1, 'Keeping Up with the Circus', '10-22-2023')
	
	SELECT @EventId1 = Id FROM tblHauntedEvent WHERE Name = 'Stay the Night for a Fright'
	INSERT INTO tblNewsLetter (Id, HauntedEventId, Description, Date)
	VALUES
	(NEWID(), @EventId1, 'Stay the Night for a Fright', '11-10-2023')
END