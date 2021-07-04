CREATE PROC GenerateId (@table varchar(50), @id varchar(50) OUTPUT)
AS
BEGIN
SET @id = Substring(@table, 0, 3) + '-' + Convert(varchar(50), NewId())
END
GO

DECLARE @newId varchar(50)
EXEC GenerateId @table = 'UsersCopy', @id = @newId OUTPUT

INSERT INTO UsersCopy
VALUES (@newId, '0978978787', '123@gmail.com', '123', 'Name', 1)

SELECT * FROM UsersCopy