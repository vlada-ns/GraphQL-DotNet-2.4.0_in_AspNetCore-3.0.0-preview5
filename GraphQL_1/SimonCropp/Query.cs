using System.Collections.Generic;
using System.Linq;
using GraphQL.EntityFramework;
using GraphQL.Types;
using GraphQL_1.Data;

namespace GraphQL_1.SimonCropp
{
    #region QueryUsedInController

    public class Query : QueryGraphType<AppDbContext>
    {
        public Query(IEfGraphQLService<AppDbContext> efGraphQlService) :
            base(efGraphQlService)
        {
            // ###################
            // Product
            // ###################
            AddQueryField(
                name: "products",
                resolve: context => context.DbContext.Product);

            #endregion

            AddSingleField(
                resolve: context => context.DbContext.Product,
                name: "product");

            AddQueryConnectionField(
                name: "productsConnection",
                resolve: context => {
<<<<<<< HEAD
                    return context.DbContext.Product;
=======

                    //var tmp5 = context.DbContext.Product
                    //    .Select(products => new
                    //    {
                    //        ProductId = products.ProductId,
                    //        Name = products.Name,
                    //        ProductNumber = products.ProductNumber,
                    //        MakeFlag = products.MakeFlag,
                    //        FinishedGoodsFlag = products.FinishedGoodsFlag, //1
                    //        Color = products.Color,
                    //        StandardCost = products.StandardCost,
                    //        ListPrice = products.ListPrice,
                    //        Size = products.Size,
                    //        SizeUnitMeasureCode = products.SizeUnitMeasureCode, //2
                    //        WeightUnitMeasureCode = products.WeightUnitMeasureCode, //3
                    //        Weight = products.Weight, //4
                    //        DaysToManufacture = products.DaysToManufacture, //5
                    //        ProductLine = products.ProductLine, //6
                    //        Class = products.Class, //7
                    //        Style = products.Style, //8
                    //        SellStartDate = products.SellStartDate,
                    //        SellEndDate = products.SellEndDate,
                    //        DiscontinuedDate = products.DiscontinuedDate, //9
                    //        Rowguid = products.Rowguid, //10
                    //        ModifiedDate = products.ModifiedDate, //11
                    //        ProductReview = products.ProductReview, //12
                    //        TransactionHistory = products.TransactionHistory, //13
                    //        ProductSubcategory = products.ProductSubcategory
                    //        //Quantity = products.TransactionHistory.Where(th => th.ProductId == products.ProductId).Count(th => th.Quantity > 0)
                    //    });

                    //                    SELECT p.ProductID,
                    //			p.[Name],
                    //			p.ProductNumber,
                    //			p.MakeFlag,
                    //			p.Color,
                    //			p.ReorderPoint,
                    //			/* th.TransactionType, */
                    //			COUNT(th.Quantity) AS CountOfTransactionHistoryQuantity
                    //  FROM[AdventureWorks2016_EXT].[Production].[Product] p LEFT JOIN
                    //    [AdventureWorks2016_EXT].[Production].[TransactionHistory] th
                    //ON p.ProductID = th.ProductID
                    ///* WHERE th.TransactionType = 'W'	OR
                    //		th.TransactionType = 'P'	OR
                    //		th.TransactionType = 'S'	OR
                    //		th.TransactionType IS NULL */
                    //  GROUP BY  p.ProductID, p.[Name], p.ProductNumber, p.MakeFlag, p.Color, p.ReorderPoint /* th.TransactionType */
                    //  ORDER BY p.ProductID


                    //                    SELECT p.ProductID,
                    //			p.[Name],
                    //			p.ProductNumber,
                    //			p.MakeFlag,
                    //			p.Color,
                    //			p.ReorderPoint,
                    //			COUNT(th.Quantity) AS CountOfTransactionHistoryQuantity
                    //  FROM[AdventureWorks2016_EXT].[Production].[Product] p LEFT JOIN
                    //    [AdventureWorks2016_EXT].[Production].[TransactionHistory] th
                    //ON p.ProductID = th.ProductID
                    //  GROUP BY  p.ProductID, p.[Name], p.ProductNumber, p.MakeFlag, p.Color, p.ReorderPoint /* th.TransactionType */
                    //  ORDER BY p.ProductID

                    var products = context.DbContext.Product;
                    return products;
>>>>>>> parent of 9ec4158... Revert "Client now consume vProductsConnection (instead of productsConnection) - that is new view in DB"
                },
                pageSize: int.MaxValue);

            AddQueryField(
                name: "productsByArgument",
                resolve: context =>
                {
                    var content = context.GetArgument<string>("color");
                    return context.DbContext.Product.Where(x => x.Color == content);
                },
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>
                    {
                        Name = "color"
                    }));

            // ###################
            // View_ProductTransHistQuantity3
            // ###################
            //AddQueryField(
            //    name: "View_ProductTransHistQuantity3",
            //    resolve: context => context.DbContext.View_ProductTransHistQuantity);

            //AddSingleField(
            //    resolve: context => context.DbContext.View_ProductTransHistQuantity,
            //    name: "vProductTransHistQuantity");

            AddQueryConnectionField(
                name: "vProductsConnection",       //View_ProductTransHistQuantity3Connection
                resolve: context => {
                    return context.DbContext.View_ProductTransHistQuantity;
                },
                pageSize: int.MaxValue);

            //AddQueryField(
            //    name: "vProductTransHistQuantitiesByArgument",
            //    resolve: context =>
            //    {
            //        var content = context.GetArgument<string>("color");
            //        return context.DbContext.View_ProductTransHistQuantity.Where(x => x.Color == content);
            //    },
            //    arguments: new QueryArguments(
            //        new QueryArgument<StringGraphType>
            //        {
            //            Name = "color"
            //        }));


            // ###################
            // ProductReview
            // ###################
            AddQueryField(
                name: "productReviews",
                resolve: context => context.DbContext.ProductReview);

            AddSingleField(
                resolve: context => context.DbContext.ProductReview,
                name: "productReview");

            AddQueryConnectionField(
                name: "productReviewsConnection",
                resolve: context => context.DbContext.ProductReview);

            AddQueryField(
                name: "productReviewsByArgument",
                resolve: context =>
                {
                    var content = context.GetArgument<string>("reviewerName");
                    return context.DbContext.ProductReview.Where(x => x.ReviewerName == content);
                },
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>
                    {
                        Name = "reviewerName"
                    }));

            // ###################
            // ProductCategory
            // ###################
            AddQueryField(
                name: "productCategories",
                resolve: context => context.DbContext.ProductCategory);

            AddQueryField(
                name: "productCategoriesByArgument",
                resolve: context =>
                {
                    var content = context.GetArgument<string>("name");
                    return context.DbContext.ProductCategory.Where(x => x.Name == content);
                },
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>
                    {
                        Name = "name"
                    }));

            AddQueryConnectionField(
                name: "productCategoriesConnection",
                resolve: context => context.DbContext.ProductCategory);

            // ###################
            // ProductSubcategory
            // ###################
            AddQueryField(
                name: "productSubcategories",
                resolve: context => context.DbContext.ProductSubcategory);

            AddQueryField(
                name: "productSubcategoriesByArgument",
                resolve: context =>
                {
                    var content = context.GetArgument<string>("name");
                    return context.DbContext.ProductSubcategory.Where(x => x.Name == content);
                },
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>
                    {
                        Name = "name"
                    }));

            AddQueryConnectionField(
                name: "productSubcategoriesConnection",
                resolve: context => context.DbContext.ProductSubcategory);

            // ###################
            // TransactionHistory
            // ###################
            AddQueryField(
                name: "transactionHistories",
                resolve: context => context.DbContext.TransactionHistory);

            AddQueryField(
                name: "transactionHistoriesByArgument",
                resolve: context =>
                {
                    var content = context.GetArgument<int>("transactionId");
                    return context.DbContext.TransactionHistory.Where(x => x.TransactionId == content);
                },
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType>
                    {
                        Name = "transactionId"
                    }));

            AddQueryConnectionField(
                name: "transactionHistoriesConnection",
                resolve: context => context.DbContext.TransactionHistory);

            // ###################
            // Student
            // ###################
            AddQueryField(
                name: "students",
                resolve: context => context.DbContext.Students);

            // ###################
            // Grade
            // ###################
            AddQueryField(
                name: "grades",
                resolve: context => context.DbContext.Grades);

            // ###################
            // House
            // ###################
            AddQueryField(
                name: "houses",
                resolve: context => context.DbContext.House);

            // ###################
            // Window
            // ###################
            AddQueryField(
                name: "windows",
                resolve: context => context.DbContext.Window);


            // **********************************************************************************************
            // ManuallyApplyWhere NOT IMPLEMENTED --> ORIGINAL FROM --> SimonCropp / GraphQL.EntityFramework
            // **********************************************************************************************
            #region ManuallyApplyWhere

            //Field<ListGraphType<EmployeeSummaryGraph>>(
            //    name: "employeeSummary",
            //    arguments: new QueryArguments(
            //        new QueryArgument<ListGraphType<WhereExpressionGraph>>
            //        {
            //            Name = "where"
            //        }
            //    ),
            //    resolve: context =>
            //    {
            //        var dbContext = (GraphQlEfSampleDbContext)context.UserContext;
            //        IQueryable<Employee> query = dbContext.Employees;

            //        if (context.HasArgument("where"))
            //        {
            //            var wheres = context.GetArgument<List<WhereExpression>>("where");
            //            foreach (var where in wheres)
            //            {
            //                var predicate = ExpressionBuilder<Employee>.BuildPredicate(where);
            //                query = query.Where(predicate);
            //            }
            //        }

            //        return from q in query
            //               group q by new { q.CompanyId }
            //            into g
            //               select new EmployeeSummary
            //               {
            //                   CompanyId = g.Key.CompanyId,
            //                   AverageAge = g.Average(x => x.Age),
            //               };
            //    });

            #endregion
        }
    }
}
