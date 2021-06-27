SELECT * FROM Customers
WHERE Region = 'SP'
EXCEPT
SELECT * FROM Customers
WHERE City = 'Campinas';