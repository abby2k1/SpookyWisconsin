BEGIN
	INSERT INTO tblMerchType (Id, Name)
	VALUES
	(NEWID(), 'Shirt'),
    (NEWID(), 'T-Shirt'),
    (NEWID(), 'Hat'),
    (NEWID(), 'Sticker'),
	(NEWID(), 'Womens'),
	(NEWID(), 'Mens')
END