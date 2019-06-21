  CREATE VIEW View_ProductTransHistQuantity3
  AS
  SELECT	p.ProductID,
			p.[Name],
			p.ProductNumber,
			p.MakeFlag,
			p.[FinishedGoodsFlag],
			p.Color,
			p.[SafetyStockLevel],
			p.ReorderPoint,
			p.[StandardCost],
			p.[ListPrice],
			p.[Size],
			p.[SizeUnitMeasureCode],
			p.[WeightUnitMeasureCode],
			p.[Weight],
			p.[DaysToManufacture],
			p.[ProductLine],
			p.[Class],
			p.[Style],
			p.[ProductSubcategoryID],
			p.[ProductModelID],
			p.[SellStartDate],
			p.[SellEndDate],
			p.[DiscontinuedDate],
			p.[rowguid],
			p.[ModifiedDate],
			COUNT (th.Quantity) AS CountOfTransactionHistoryQuantity
  FROM		[AdventureWorks2016_EXT].[Production].[Product] p	LEFT JOIN
			[AdventureWorks2016_EXT].[Production].[TransactionHistory] th
  ON p.ProductID = th.ProductID
  GROUP BY	p.ProductID, p.[Name], p.ProductNumber, p.MakeFlag, p.[FinishedGoodsFlag], p.Color, p.[SafetyStockLevel], p.ReorderPoint, p.[StandardCost], p.[ListPrice],
  p.[Size], p.[SizeUnitMeasureCode], p.[WeightUnitMeasureCode], p.[Weight], p.[DaysToManufacture], p.[ProductLine], p.[Class], p.[Style], p.[ProductSubcategoryID],
  p.[ProductModelID], p.[SellStartDate], p.[SellEndDate], p.[DiscontinuedDate], p.[rowguid], p.[ModifiedDate]