INSERT INTO Region VALUES (5, 'desc');

SELECT r.RegionID, r.RegionDescription
FROM Region r
LEFT JOIN Territories t
ON r.RegionID = t.RegionID
LEFT JOIN EmployeeTerritories eT
ON t.TerritoryID = eT.TerritoryID
GROUP BY r.RegionID, r.RegionDescription
HAVING COUNT(eT.EmployeeID) = 0