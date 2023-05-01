
CREATE VIEW [PackingItemsInCarton] AS
SELECT p.Id, p.[CartonNo.] FROM PackingList p


CREATE VIEW [SparePartByManufacture] AS
SELECT m.ContactName, s.Name FROM Manufacturer m INNER JOIN SparePart s ON m.Id= s.ManuacturerId



.
CREATE PROCEDURE CBD
@Name Varchar(100)
AS
BEGIN
SELECT p.Dimension, p.ManufacturerId FROM PlaceOrder P
END



CREATE PROCEDURE abcdef
@Id Varchar(100)
AS
BEGIN
SELECT c.Name FROM SparePart c WHERE c.Id=Id
END