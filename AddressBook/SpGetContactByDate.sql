
CREATE PROCEDURE [dbo].[SpGetContactByDate]
@date varchar(255)
AS
	SELECT firstName, lastName, address, city, state, zipCode, phoneNumber, email FROM Contacts 
	WHERE date_added between  CAST(@date as date) and CAST('2021-07-13' as date)
RETURN 0