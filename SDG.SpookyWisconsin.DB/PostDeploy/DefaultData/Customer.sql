BEGIN
	DECLARE @UserId1 uniqueidentifier
	DECLARE @MemberId1 uniqueidentifier
	DECLARE @AddressId1 uniqueidentifier
	SELECT @UserId1 = Id FROM tblUser WHERE Username = 'pricev31'
	SELECT @MemberId1 = Id FROM tblMember WHERE NewsLetterOpt = 'Yes' AND MemberOpt = 'Yes'
	SELECT @AddressId1 = Id FROM tblAddress WHERE Street = '3420 E Calumet St'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, AddressId, Email)
	VALUES
	(NEWID(), @MemberId1, @UserId1, 'Vincent', 'Price', @AddressId1, 'pricev31@gmail.com')
	SELECT @MemberId1 = Id FROM tblMember WHERE NewsLetterOpt = 'Yes' AND MemberOpt = 'No'
	SELECT @UserId1 = Id FROM tblUser WHERE Username = 'kingpop1984'
	SELECT @AddressId1 = Id FROM tblAddress WHERE Street = '3400 E Calumet St'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, AddressId, Email)
	VALUES
	(NEWID(), @MemberId1, @UserId1, 'Michael', 'Jackson', @AddressId1, 'kingpop1984@yahoo.com')
	SELECT @MemberId1 = Id FROM tblMember WHERE NewsLetterOpt = 'No' AND MemberOpt = 'Yes'
	SELECT @UserId1 = Id FROM tblUser WHERE Username = 'mortaddams11'
	SELECT @AddressId1 = Id FROM tblAddress WHERE Street = '3330 E Calumet St'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, AddressId, Email)
	VALUES
	(NEWID(), @MemberId1, @UserId1, 'Morticia', 'Addams', @AddressId1, 'mortaddams11@gmail.com')
	SELECT @MemberId1 = Id FROM tblMember WHERE NewsLetterOpt = 'No' AND MemberOpt = 'No'
	SELECT @UserId1 = Id FROM tblUser WHERE Username = 'wedaddams.1600'
	SELECT @AddressId1 = Id FROM tblAddress WHERE Street = '3310 E Calumet St'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, AddressId, Email)
	VALUES
	(NEWID(), @MemberId1, @UserId1, 'Wednesday', 'Addams', @AddressId1, 'wedaddams.1600@hotmail.com')
END