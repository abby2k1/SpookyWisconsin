BEGIN
DECLARE @TierId uniqueidentifier
DECLARE @NewsLetterId uniqueidentifier
SELECT @TierId = Id FROM tblTier WHERE TierName = 'Bronze'
SELECT @NewsLetterId = Id FROM tblNewsLetter WHERE Date = '10-01-2023'
INSERT INTO tblMember (Id, TierId, NewsLetterId, NewsLetterOpt, MemberOpt)
VALUES
(NEWID(), @TierId, @NewsLetterId, 'Yes', 'Yes')
SELECT @TierId = Id FROM tblTier WHERE TierName = 'Silver'
SELECT @NewsLetterId = Id FROM tblNewsLetter WHERE Date = '10-15-2023'
INSERT INTO tblMember (Id, TierId, NewsLetterId, NewsLetterOpt, MemberOpt)
VALUES
(NEWID(), @TierId, @NewsLetterId, 'Yes', 'No')
SELECT @TierId = Id FROM tblTier WHERE TierName = 'Gold'
SELECT @NewsLetterId = Id FROM tblNewsLetter WHERE Date = '10-22-2023'
INSERT INTO tblMember (Id, TierId, NewsLetterId, NewsLetterOpt, MemberOpt)
VALUES
(NEWID(), @TierId, @NewsLetterId, 'No', 'Yes')
SELECT @TierId = Id FROM tblTier WHERE TierName = 'Bronze'
SELECT @NewsLetterId = Id FROM tblNewsLetter WHERE Date = '11-10-2023'
INSERT INTO tblMember (Id, TierId, NewsLetterId, NewsLetterOpt, MemberOpt)
VALUES
(NEWID(), @TierId, @NewsLetterId, 'No', 'No')
END