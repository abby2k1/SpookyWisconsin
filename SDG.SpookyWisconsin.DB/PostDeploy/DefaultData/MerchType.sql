BEGIN
	INSERT INTO tblMerchType (Id, Name)
	VALUES
	(NEWID(), 'Shirt'),
    (NEWID(), 'T-Shirt'),
    (NEWID(), 'Hoodie'),
    (NEWID(), 'Hat'),
    (NEWID(), 'Sweatshirt'),
    (NEWID(), 'Mug'),
    (NEWID(), 'Keychain'),
    (NEWID(), 'Sticker'),
    (NEWID(), 'Poster'),
    (NEWID(), 'Other'),
	(NEWID(), 'Womens'),
	(NEWID(), 'Mens'),
	(NEWID(), 'Kids')
END