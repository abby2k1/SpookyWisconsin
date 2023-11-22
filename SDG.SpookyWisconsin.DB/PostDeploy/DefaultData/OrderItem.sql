BEGIN
DECLARE @OrderId uniqueidentifier
DECLARE @MerchId uniqueidentifier
SELECT @OrderId = Id FROM tblOrder WHERE OrderDate = '11-02-2023'
SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Long Sleeve Shirt'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity)
VALUES
(NEWID(), @OrderId, @MerchId, 1)
SELECT @OrderId = Id FROM tblOrder WHERE OrderDate = '11-09-2023'
SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Hat'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity)
VALUES
(NEWID(), @OrderId, @MerchId, 1)
SELECT @OrderId = Id FROM tblOrder WHERE OrderDate = '11-16-2023'
SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Ghoul Shirt'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity)
VALUES
(NEWID(), @OrderId, @MerchId, 1)
SELECT @OrderId = Id FROM tblOrder WHERE OrderDate = '12-01-2023'
SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Haunted House Sticker'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity)
VALUES
(NEWID(), @OrderId, @MerchId, 1)
SELECT @MerchId = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Long Sleeve Shirt'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity)
VALUES
(NEWID(), @OrderId, @MerchId, 2)
END