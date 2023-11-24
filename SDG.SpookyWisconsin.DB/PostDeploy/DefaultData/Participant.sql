BEGIN
	DECLARE @HauntedEventId uniqueidentifier
	DECLARE @CustomerId1 uniqueidentifier
	SELECT @HauntedEventId = Id FROM tblHauntedEvent WHERE Name = 'Veteran Walk-Through in Forest Hill Cemetery'
	SELECT @CustomerId1 = Id FROM tblCustomer WHERE FirstName = 'Vincent'
	INSERT INTO tblParticipant (Id, HauntedEventId, CustomerId)
	VALUES
	(NEWID(), @HauntedEventId, @CustomerId1)

	SELECT @HauntedEventId = Id FROM tblHauntedEvent WHERE Name = 'Kate Blood Gravestone Story Time'
	SELECT @CustomerId1 = Id FROM tblCustomer WHERE FirstName = 'Michael'
	INSERT INTO tblParticipant (Id, HauntedEventId, CustomerId)
	VALUES
	(NEWID(), @HauntedEventId, @CustomerId1)

	SELECT @HauntedEventId = Id FROM tblHauntedEvent WHERE Name = 'Keeping Up with the Circus'
	SELECT @CustomerId1 = Id FROM tblCustomer WHERE FirstName = 'Morticia'
	INSERT INTO tblParticipant (Id, HauntedEventId, CustomerId)
	VALUES
	(NEWID(), @HauntedEventId, @CustomerId1)

	SELECT @HauntedEventId = Id FROM tblHauntedEvent WHERE Name = 'Stay the Night for a Fright'
	SELECT @CustomerId1 = Id FROM tblCustomer WHERE FirstName = 'Wednesday'
	INSERT INTO tblParticipant (Id, HauntedEventId, CustomerId)
	VALUES
	(NEWID(), @HauntedEventId, @CustomerId1)
END