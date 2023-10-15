BEGIN
	INSERT INTO tblOrder (Id, InCartId, CustomerId, OrderDate, DeliverDate)
	VALUES
	(1, 1, 1, '11-02-2023', '11-09-2023'),
	(2, 2, 2, '11-09-2023', '11-16-2023'),
	(3, 3, 3, '11-20-2023', '11-27-2023'),
	(4, 4, 4, '12-01-2023', '12-08-2023')
END