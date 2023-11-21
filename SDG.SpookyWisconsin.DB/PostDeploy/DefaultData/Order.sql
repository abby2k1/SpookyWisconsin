BEGIN
	DECLARE @CustomerId uniqueidentifier
	DECLARE @UserId uniqueidentifier
	SELECT @CustomerId = Id FROM tblCustomer WHERE FirstName = 'Vincent'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'pricev31'
	INSERT INTO tblOrder (Id, CustomerId, OrderDate, UserId, ShipDate)
	VALUES
	(NEWID(), @CustomerId, '11-02-2023', @UserId, '11-09-2023')
	SELECT @CustomerId = Id FROM tblCustomer WHERE FirstName = 'Michael'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'kingpop1984'
	INSERT INTO tblOrder (Id, CustomerId, OrderDate, UserId, ShipDate)
	VALUES
	(NEWID(), @CustomerId, '11-09-2023', @UserId, '11-16-2023')
	SELECT @CustomerId = Id FROM tblCustomer WHERE FirstName = 'Morticia'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'mortaddams11'
	INSERT INTO tblOrder (Id, CustomerId, OrderDate, UserId, ShipDate)
	VALUES
	(NEWID(), @CustomerId, '11-16-2023', @UserId, '11-23-2023')
	SELECT @CustomerId = Id FROM tblCustomer WHERE FirstName = 'Wednesday'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'wedaddams.1600'
	INSERT INTO tblOrder (Id, CustomerId, OrderDate, UserId, ShipDate)
	VALUES
	(NEWID(), @CustomerId, '12-01-2023', @UserId, '12-08-2023')
END