BEGIN
    DECLARE @AddressId uniqueidentifier;
    SELECT @AddressId = Id FROM tblAddress WHERE Street = '6517 Lynch Bridge Rd';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Siren Bridge')

	SELECT @AddressId = Id FROM tblAddress WHERE Street = 'W4266 County Hwy X';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Clark County Insane Asylum')

	SELECT @AddressId = Id FROM tblAddress WHERE Street = '1202 Northport Dr';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Sanatorium Hill')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '1 Speedway Rd';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Forest Hill Cemetery')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '1201 Main Rd';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Nelsen Hall')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = 'Callan Rd';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Witch Road')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '276 Linden St';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Octagon House')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '431 North St';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Dartford Cemetery')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '321 Main St';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'City of Black River Falls')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '15401 County Rd R';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Hotel Hell')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '424 E Wisconsin Ave';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'The Pfister Hotel')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '2308 W Wisconsin Ave';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Ambassador Hotel')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '11811 W Watertown Plank Rd';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Morris Pratt Institute')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '116 W Wisconsin Ave';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Riverside Theater')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '714 N Owaissa St';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Riverside Cemetery')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = 'Boy Scout Lane';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Boy Scout Lane')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = 'W Clark St';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Bloody Bride Bridge')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '623 Broadway St';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Al Ringling Mansion')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '135 Walnut St';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Old Baraboo Inn')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = 'Helen Creek Rd';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Summerwind Mansion')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = 'N6590 5th Ave';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Plainfield Cemetery')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '100 High Ave';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'The Grand Opera House')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '4100 Treffert Dr';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Winnebago Mental Health Institute')
	
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '2304 S Galvin Ave';
	INSERT INTO tblHauntedLocation (Id, AddressId, Name)
	VALUES
	(NEWID(), @AddressId, 'Wood County Insane Asylum')
END