CREATE TABLE [dbo].[ProductsCopy](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[SellerId] [int] NULL);

INSERT INTO ProductsCopy
SELECT * FROM Products;

SELECT * FROM ProductsCopy;