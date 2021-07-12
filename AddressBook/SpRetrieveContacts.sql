CREATE PROCEDURE [dbo].[SpRetrieveContacts]
AS
	SELECT firstName, lastName, address, city, state, zipCode, phoneNumber, email FROM Contacts;
RETURN 0
