BEGIN
    DECLARE @AddressId uniqueidentifier;
    DECLARE @CountyId uniqueidentifier;
    SELECT @AddressId = Id FROM tblAddress WHERE Street = '6517 Lynch Bridge Rd';
    SELECT @CountyId = Id FROM tblCounty WHERE Name = 'Dane';
	INSERT INTO tblHauntedLocation (Id, AddressId, CountyId, Name)
	VALUES
	(NEWID(), 1, 1, 'Siren Bridge'),
	(NEWID(), 2, 2, 'Clark County Insane Asylum'),
	(NEWID(), 3, 3, 'Sanatorium Hill'),
	(NEWID(), 4, 3, 'Forest Hill Cemetery'),
	(NEWID(), 5, 4, 'Nelsen Hall'),
	(NEWID(), 6, 5, 'Witch Road'),
	(NEWID(), 7, 5, 'Octagon House'),
	(NEWID(), 8, 6, 'Dartford Cemetery'),
	(NEWID(), 9, 7, 'City of Black River Falls'),
	(NEWID(), 10, 8, 'Hotel Hell'),
	(NEWID(), 11, 9, 'The Pfister Hotel'),
	(NEWID(), 12, 9, 'Ambassador Hotel'),
	(NEWID(), 13, 9, 'Morris Pratt Institute'),
	(NEWID(), 14, 9, 'Riverside Theater'),
	(NEWID(), 15, 10, 'Riverside Cemetery'),
	(NEWID(), 16, 11, 'Boy Scout Lane'),
	(NEWID(), 17, 11, 'Bloody Bride Bridge'),
	(NEWID(), 18, 12, 'Al Ringling Mansion'),
	(NEWID(), 19, 12, 'Old Baraboo Inn'),
	(NEWID(), 20, 13, 'Summerwind Mansion'),
	(NEWID(), 21, 14, 'Plainfield Cemetery'),
	(NEWID(), 22, 15, 'The Grand Opera House'),
	(NEWID(), 23, 15, 'Winnebago Mental Health Institute'),
	(NEWID(), 24, 16, 'Wood County Insane Asylum')
END