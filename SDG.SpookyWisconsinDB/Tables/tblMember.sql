CREATE TABLE [dbo].[tblMember]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TierId] INT NOT NULL, 
    [NewsLetterId] INT NOT NULL, 
    [NewsLetterOpt] VARCHAR(50) NOT NULL, 
    [MemberOpt] VARCHAR(50) NOT NULL
)
