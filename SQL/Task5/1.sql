CREATE PROC MergeXML @Request xml
AS
BEGIN TRANSACTION

BEGIN TRY
DECLARE @docXML int
EXEC sp_XML_preparedocument @docXML OUTPUT, @request

CREATE TABLE UsersTemp
([Id] [int],
[Password] [nvarchar](50),
[Name] [nvarchar](50))
INSERT INTO UsersTemp
SELECT * FROM
OPENXML (@docXML, '/Users/User', 2)
WITH
([Id] [int],
[Password] [nvarchar](50),
[Name] [nvarchar](50))

MERGE UsersNew u
USING UsersTemp uTemp
ON (u.Id = uTemp.Id)
WHEN MATCHED
THEN UPDATE SET u.Name = uTemp.Name, u.Password = uTemp.Password
WHEN NOT MATCHED
THEN INSERT VALUES (uTemp.Id, uTemp.Password, uTemp.Name);
DROP TABLE UsersTemp
COMMIT
EXEC sp_XML_removedocument @docXML
END TRY

BEGIN CATCH
ROLLBACK
EXEC sp_XML_removedocument @docXML
END CATCH
GO

DECLARE @doc varchar(1000);  
SET @doc ='  
<Users>  
	<User>
		<Id>1</Id>
		<Password>123</Password>
		<Name>John</Name>
	</User>
</Users>'  

EXEC MergeXML @doc

SELECT * FROM UsersNew