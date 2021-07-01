SELECT FirstName, LastName, TerritoryDescription, RegionDescription
FROM Employees e
JOIN EmployeeTerritories eT
ON e.EmployeeID = eT.EmployeeID 
JOIN Territories t
ON eT.TerritoryID = t.TerritoryID
JOIN Region r
ON t.RegionID = r.RegionID