BEGIN
	INSERT INTO tblCart (Id, CustomerId, MerchId, Quantity, TotalCost)
	VALUES
	(NEWID(), 1, 2, 2, 18.96),
	(NEWID(), 2, 1, 10, 31.54),
	(NEWID(), 3, 4, 3, 52.71),
	(NEWID(), 4, 3, 1, 21.08)
END