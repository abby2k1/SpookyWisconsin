BEGIN
	DECLARE @UserId uniqueidentifier
	DECLARE @MemberId uniqueidentifier
	DECLARE @AddressId uniqueidentifier
	SELECT @UserId = Id FROM tblUser WHERE Username = 'pricev31'
	SELECT @MemberId = Id FROM tblMember WHERE NewsLetterOpt = 'Yes' AND MemberOpt = 'Yes'
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '3420 E Calumet St'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, AddressId, Email)
	VALUES
	(NEWID(), @MemberId, @UserId, 'Vincent', 'Price', @AddressId, 'pricev31@gmail.com')
	SELECT @MemberId = Id FROM tblMember WHERE NewsLetterOpt = 'Yes' AND MemberOpt = 'No'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'kingpop1984'
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '3400 E Calumet St'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, AddressId, Email)
	VALUES
	(NEWID(), @MemberId, @UserId, 'Michael', 'Jackson', @AddressId, 'kingpop1984@yahoo.com')
	SELECT @MemberId = Id FROM tblMember WHERE NewsLetterOpt = 'No' AND MemberOpt = 'Yes'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'mortaddams11'
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '3330 E Calumet St'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, AddressId, Email)
	VALUES
	(NEWID(), @MemberId, @UserId, 'Morticia', 'Addams', @AddressId, 'mortaddams11@gmail.com')
	SELECT @MemberId = Id FROM tblMember WHERE NewsLetterOpt = 'No' AND MemberOpt = 'No'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'wedaddams.1600'
	SELECT @AddressId = Id FROM tblAddress WHERE Street = '3310 E Calumet St'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, AddressId, Email)
	VALUES
	(NEWID(), @MemberId, @UserId, 'Wednesday', 'Addams', @AddressId, 'wedaddams.1600@hotmail.com')
END