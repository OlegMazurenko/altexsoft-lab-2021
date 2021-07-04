CREATE FUNCTION GenerateIdFunction (@table varchar(50), @id varchar(50))
RETURNS varchar(50)
BEGIN
RETURN Substring(@table, 1, 4) + '-' + Convert(varchar(50), @id)
END
GO

INSERT INTO UsersCopy
VALUES (dbo.GenerateIdFunction('UsersCopy', NewId()), '0978978787', '123@gmail.com', '123', 'Name', 2)

SELECT * FROM UsersCopy