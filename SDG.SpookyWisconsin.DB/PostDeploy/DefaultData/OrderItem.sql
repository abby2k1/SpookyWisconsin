BEGIN
DECLARE @OrderId uniqueidentifier
DECLARE @MerchId1 uniqueidentifier
SELECT @OrderId = Id FROM tblOrder WHERE OrderDate = '11-02-2023'
SELECT @MerchId1 = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Short Sleeve Shirt'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity, Cost)
VALUES
(NEWID(), @OrderId, @MerchId1, 1, 1.50)
SELECT @OrderId = Id FROM tblOrder WHERE OrderDate = '11-09-2023'
SELECT @MerchId1 = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Hat'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity, Cost)
VALUES
(NEWID(), @OrderId, @MerchId1, 1, 0.85)
SELECT @OrderId = Id FROM tblOrder WHERE OrderDate = '11-16-2023'
SELECT @MerchId1 = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Tumbler'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity, Cost)
VALUES
(NEWID(), @OrderId, @MerchId1, 1, 9.75)
SELECT @OrderId = Id FROM tblOrder WHERE OrderDate = '12-01-2023'
SELECT @MerchId1 = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Tote'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity, Cost)
VALUES
(NEWID(), @OrderId, @MerchId1, 1, 96.96)
SELECT @MerchId1 = Id FROM tblMerch WHERE MerchName = 'Spooky Wisconsin Short Sleeve Shirt'
INSERT INTO tblOrderItem (Id, OrderId, MerchId, Quantity, Cost)
VALUES
(NEWID(), @OrderId, @MerchId1, 2, 400.35)
END