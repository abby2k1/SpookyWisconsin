﻿CREATE TABLE [dbo].[tblTier]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [TierName] VARCHAR(50) NOT NULL, 
    [TierLevel] INT NOT NULL
)
