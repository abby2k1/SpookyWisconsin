BEGIN
	INSERT INTO tblMerch (Id, MerchName, InStkQty, Description, Cost)
	VALUES
	(NEWID(), 'Spooky Wisconsin Long Sleeve Shirt', 4, 'Long Sleeve with Spooky Wisconsin Logo', 19.99),
	(NEWID(), 'Spooky Wisconsin Hat', 10, 'Baseball cap with Spooky Wisconsin Logo', 14.99),
	(NEWID(), 'Ghoul Shirt', 5, 'Short Sleeve with Ghost', 14.99),
	(NEWID(), 'Haunted House Sticker', 20, 'Image of a Haunted House', 2.99)
END