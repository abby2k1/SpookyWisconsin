BEGIN
    DECLARE @MerchTypeId uniqueidentifier
    DECLARE @MerchId uniqueidentifier
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Shirt'
    SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Short Sleeve Shirt'
	INSERT INTO tblMerchTypeMerch (Id, MerchTypeId, MerchId)
    VALUES
    (NEWID(), @MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Mens'
    INSERT INTO tblMerchTypeMerch (Id, MerchTypeId, MerchId)
    VALUES
    (NEWID(), @MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Womens'
	INSERT INTO tblMerchTypeMerch (Id, MerchTypeId, MerchId)
	VALUES
	(NEWID(), @MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Tumbler'
    SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Tumbler'
	INSERT INTO tblMerchTypeMerch (Id, MerchTypeId, MerchId)
	VALUES
	(NEWID(), @MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Hat'
    SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Hat'
	INSERT INTO tblMerchTypeMerch (Id, MerchTypeId, MerchId)
	VALUES
	(NEWID(), @MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Tote'
    SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Tote'
    INSERT INTO tblMerchTypeMerch (Id, MerchTypeId, MerchId)
    VALUES
	(NEWID(), @MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Mens'
    INSERT INTO tblMerchTypeMerch (Id, MerchTypeId, MerchId)
    VALUES
    (NEWID(), @MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Shirt'
    INSERT INTO tblMerchTypeMerch (Id, MerchTypeId, MerchId)
    VALUES
    (NEWID(), @MerchTypeId, @MerchId)
END