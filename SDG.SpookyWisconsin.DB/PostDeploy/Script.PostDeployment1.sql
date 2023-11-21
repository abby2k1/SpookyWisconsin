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
:r .\DefaultData\Address.sql
:r .\DefaultData\User.sql
:r .\DefaultData\Participant.sql
:r .\DefaultData\HauntedLocation.sql
:r .\DefaultData\Member.sql
:r .\DefaultData\Customer.sql
:r .\DefaultData\HauntedEvent.sql
:r .\DefaultData\Merch.sql
:r .\DefaultData\MerchType.sql
:r .\DefaultData\MerchTypeMerch.sql
:r .\DefaultData\NewsLetter.sql
:r .\DefaultData\Order.sql
:r .\DefaultData\OrderItem.sql
:r .\DefaultData\Tier.sql
:r .\DefaultData\Tour.sql
