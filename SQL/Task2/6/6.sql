SELECT Country, Region, COUNT(*) AS ProviderCount
FROM Suppliers
WHERE Region IS NOT NULL
GROUP BY Country, Region
HAVING COUNT(*) > 1