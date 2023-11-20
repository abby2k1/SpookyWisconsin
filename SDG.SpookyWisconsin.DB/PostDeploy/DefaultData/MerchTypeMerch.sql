BEGIN
    DECLARE @MerchTypeId uniqueidentifier
    DECLARE @MerchId uniqueidentifier
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'T-Shirt'
    SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Long Sleeve Shirt'
	INSERT INTO tblMerchTypeMerch (MerchTypeId, MerchId)
    VALUES
    (@MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Shirt'
    INSERT INTO tblMerchTypeMerch (MerchTypeId, MerchId)
    VALUES
    (@MerchTypeId, @MerchId)
    SELECT @MerchTypeId = Id FROM tblMerchType WHERE Name = 'Mens'
    INSERT INTO tblMerchTypeMerch (MerchTypeId, MerchId)
    VALUES
    (@MerchTypeId, @MerchId)
END