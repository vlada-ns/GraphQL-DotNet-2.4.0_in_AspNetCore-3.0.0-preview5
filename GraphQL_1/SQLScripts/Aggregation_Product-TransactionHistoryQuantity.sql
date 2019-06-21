  SELECT	p.ProductID,
			p.[Name],
			p.ProductNumber,
			p.MakeFlag,
			p.Color,
			p.ReorderPoint,
			/* th.TransactionType, */
			COUNT (th.Quantity) AS CountOfTransactionHistoryQuantity
  FROM		[AdventureWorks2016_EXT].[Production].[Product] p	LEFT JOIN
			[AdventureWorks2016_EXT].[Production].[TransactionHistory] th
  ON p.ProductID = th.ProductID
/* WHERE th.TransactionType = 'W'	OR
		th.TransactionType = 'P'	OR
		th.TransactionType = 'S'	OR
		th.TransactionType IS NULL */
  GROUP BY	p.ProductID, p.[Name], p.ProductNumber, p.MakeFlag, p.Color, p.ReorderPoint /* th.TransactionType */
  ORDER BY p.ProductID