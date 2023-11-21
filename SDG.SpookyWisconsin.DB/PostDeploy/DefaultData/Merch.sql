BEGIN
	INSERT INTO tblMerch (Id, MerchName, InStkQty, Description, Cost, ImagePath)
	VALUES
	(NEWID(), 'Spooky Wisconsin Long Sleeve Shirt', 4, 'Long Sleeve with Spooky Wisconsin Logo', 19.99, 'SWLSS.png'),
	(NEWID(), 'Spooky Wisconsin Hat', 10, 'Baseball cap with Spooky Wisconsin Logo', 14.99, 'SWH.png'),
	(NEWID(), 'Ghoul Shirt', 5, 'Short Sleeve with Ghost', 14.99, 'GS.png'),
	(NEWID(), 'Haunted House Sticker', 20, 'Image of a Haunted House', 2.99, 'HHS.png')
END