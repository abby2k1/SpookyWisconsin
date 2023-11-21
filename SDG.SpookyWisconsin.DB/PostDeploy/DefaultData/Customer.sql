BEGIN
	DECLARE @UserId uniqueidentifier
	DECLARE @MemberId uniqueidentifier
	SELECT @MemberId = Id FROM tblMember WHERE NewsLetterOpt = 'Yes' AND MemberOpt = 'Yes'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'pricev31'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, Address, Email)
	VALUES
	(NEWID(), 1, 1, 'Vincent', 'Price', '12 North Ln', 'pricev31@gmail.com')
	SELECT @MemberId = Id FROM tblMember WHERE NewsLetterOpt = 'Yes' AND MemberOpt = 'No'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'kingpop1984'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, Address, Email)
	VALUES
	(NEWID(), 2, 2, 'Michael', 'Jackson', '35 Castle Dr', 'kingpop1984@yahoo.com')
	SELECT @MemberId = Id FROM tblMember WHERE NewsLetterOpt = 'No' AND MemberOpt = 'Yes'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'mortaddams11'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, Address, Email)
	VALUES
	(NEWID(), 3, 3, 'Morticia', 'Addams', '74 Dream St', 'mortaddams11@gmail.com')
	SELECT @MemberId = Id FROM tblMember WHERE NewsLetterOpt = 'No' AND MemberOpt = 'No'
	SELECT @UserId = Id FROM tblUser WHERE Username = 'wedaddams.1600'
	INSERT INTO tblCustomer (Id, MemberId, UserId, FirstName, LastName, Address, Email)
	VALUES
	(NEWID(), 4, @UserId, 'Wednesday', 'Addams', '98 Woodland Rd', 'wedaddams.1600@hotmail.com')
END