/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DROP TABLE IF EXISTS tblAddress
DROP TABLE IF EXISTS tblCart
DROP TABLE IF EXISTS tblCustomer
DROP TABLE IF EXISTS tblHauntedEvent
DROP TABLE IF EXISTS tblHauntedLocation
DROP TABLE IF EXISTS tblMember
DROP TABLE IF EXISTS tblNewsLetter
DROP TABLE IF EXISTS tblOrder
DROP TABLE IF EXISTS tblParticipant
DROP TABLE IF EXISTS tblTier
DROP TABLE IF EXISTS tblTour
DROP TABLE IF EXISTS tblUser
