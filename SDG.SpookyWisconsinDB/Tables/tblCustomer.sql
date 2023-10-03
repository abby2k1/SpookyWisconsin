CREATE TABLE [dbo].[tblCustomer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MemberId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Address] VARCHAR(75) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL
)
