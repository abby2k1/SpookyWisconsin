BEGIN
	DECLARE @HauntedEventId uniqueidentifier
	DECLARE @CustomerId uniqueidentifier
	SELECT @HauntedEventId = Id FROM tblHauntedEvent WHERE Name = 'Veteran Walk-Through in Forest Hill Cemetery'
	SELECT @CustomerId = Id FROM tblCustomer WHERE FirstName = 'Vincent'
	INSERT INTO tblParticipant (Id, HauntedEventId, CustomerId)
	VALUES
	(NEWID(), @HauntedEventId, @CustomerId)

	SELECT @HauntedEventId = Id FROM tblHauntedEvent WHERE Name = 'Kate Blood Gravestone Story Time'
	SELECT @CustomerId = Id FROM tblCustomer WHERE FirstName = 'Michael'
	INSERT INTO tblParticipant (Id, HauntedEventId, CustomerId)
	VALUES
	(NEWID(), @HauntedEventId, @CustomerId)

	SELECT @HauntedEventId = Id FROM tblHauntedEvent WHERE Name = 'Keeping Up with the Circus'
	SELECT @CustomerId = Id FROM tblCustomer WHERE FirstName = 'Morticia'
	INSERT INTO tblParticipant (Id, HauntedEventId, CustomerId)
	VALUES
	(NEWID(), @HauntedEventId, @CustomerId)

	SELECT @HauntedEventId = Id FROM tblHauntedEvent WHERE Name = 'Stay the Night for a Fright'
	SELECT @CustomerId = Id FROM tblCustomer WHERE FirstName = 'Wednesday'
	INSERT INTO tblParticipant (Id, HauntedEventId, CustomerId)
	VALUES
	(NEWID(), @HauntedEventId, @CustomerId)
END