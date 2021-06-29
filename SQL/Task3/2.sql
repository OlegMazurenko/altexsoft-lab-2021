SELECT c.CategoryName, MAX(p.UnitPrice) AS Price
FROM Categories c
JOIN Products p
ON c.CategoryID = p.CategoryID
GROUP BY c.CategoryName