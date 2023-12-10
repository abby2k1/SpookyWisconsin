BEGIN
	INSERT INTO tblMerch (Id, MerchName, InStkQty, Description, Cost, ImagePath)
	VALUES
	(NEWID(), 'Spooky Wisconsin Short Sleeve Shirt', 4, 'White Short Sleeve with Spooky Wisconsin Logo', 19.99, 'White_Shirt.png'),
	(NEWID(), 'Spooky Wisconsin Hat', 10, 'Baseball cap with Spooky Wisconsin Logo', 14.99, 'Black_Cap.png'),
	(NEWID(), 'Spooky Wisconsin Tumbler', 5, 'Black Tumbler with Spooky Wisconsin Logo', 14.99, 'Black_Tumbler.png'),
	(NEWID(), 'Spooky Wisconsin Tote', 20, 'Black Tote with Spooky Wisconsin Logo', 2.99, 'Black_tote.png')
END