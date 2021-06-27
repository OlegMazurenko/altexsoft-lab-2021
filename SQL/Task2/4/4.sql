SELECT * FROM Customers
WHERE Region = 'SP'
UNION 
SELECT * FROM Customers
WHERE City = 'Berlin';