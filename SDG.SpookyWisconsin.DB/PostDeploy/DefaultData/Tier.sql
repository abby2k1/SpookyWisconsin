BEGIN
	INSERT INTO tblTier (Id, TierName, TierLevel)
	VALUES
	(NEWID(), 'Bronze', 1),
	(NEWID(), 'Silver', 2),
	(NEWID(), 'Gold', 3)
END