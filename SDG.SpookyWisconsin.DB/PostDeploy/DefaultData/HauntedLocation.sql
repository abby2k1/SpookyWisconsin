BEGIN
    DECLARE @AddressId uniqueidentifier;
    SELECT @AddressId = Id FROM tblAddress WHERE Street = '6517 Lynch Bridge Rd';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), 1, 'Siren Bridge'),
	(NEWID(), 2, 'Clark County Insane Asylum'),
	(NEWID(), 3, 'Sanatorium Hill'),
	(NEWID(), 4, 'Forest Hill Cemetery'),
	(NEWID(), 5, 'Nelsen Hall'),
	(NEWID(), 6, 'Witch Road'),
	(NEWID(), 7, 'Octagon House'),
	(NEWID(), 8, 'Dartford Cemetery'),
	(NEWID(), 9, 'City of Black River Falls'),
	(NEWID(), 10, 'Hotel Hell'),
	(NEWID(), 11, 'The Pfister Hotel'),
	(NEWID(), 12, 'Ambassador Hotel'),
	(NEWID(), 13, 'Morris Pratt Institute'),
	(NEWID(), 14, 'Riverside Theater'),
	(NEWID(), 15, 'Riverside Cemetery'),
	(NEWID(), 16, 'Boy Scout Lane'),
	(NEWID(), 17, 'Bloody Bride Bridge'),
	(NEWID(), 18, 'Al Ringling Mansion'),
	(NEWID(), 19, 'Old Baraboo Inn'),
	(NEWID(), 20, 'Summerwind Mansion'),
	(NEWID(), 21, 'Plainfield Cemetery'),
	(NEWID(), 22, 'The Grand Opera House'),
	(NEWID(), 23, 'Winnebago Mental Health Institute'),
	(NEWID(), 24, 'Wood County Insane Asylum')
END