BEGIN
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, Address, Email)
	VALUES
	(1, 1, 1, 'Vincent', 'Price', '12 North Ln', 'pricev31@gmail.com'),
	(2, 2, 2, 'Michael', 'Jackson', '35 Castle Dr', 'kingpop1984@yahoo.com'),
	(3, 3, 3, 'Morticia', 'Addams', '74 Dream St', 'mortaddams11@gmail.com'),
	(4, 4, 4, 'Wednesday', 'Addams', '98 Woodland Rd', 'wedaddams.1600@hotmail.com')
END