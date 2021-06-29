SELECT * FROM Products
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products)