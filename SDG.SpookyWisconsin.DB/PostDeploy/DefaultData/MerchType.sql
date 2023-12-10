BEGIN
	INSERT INTO tblMerchType (Id, Name)
	VALUES
	(NEWID(), 'Shirt'),
    (NEWID(), 'Hat'),
    (NEWID(), 'Tumbler'),
	(NEWID(), 'Tote'),
	(NEWID(), 'Womens'),
	(NEWID(), 'Mens')
END