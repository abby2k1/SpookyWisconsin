/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\DefaultData\Addresses.sql
:r .\DefaultData\Carts.sql
:r .\DefaultData\Customers.sql
:r .\DefaultData\HauntedEvents.sql
:r .\DefaultData\HauntedLocations.sql
:r .\DefaultData\Members.sql
:r .\DefaultData\Merchs.sql
:r .\DefaultData\NewsLetters.sql
:r .\DefaultData\Orders.sql
:r .\DefaultData\Participants.sql
:r .\DefaultData\Tiers.sql
:r .\DefaultData\Tours.sql
