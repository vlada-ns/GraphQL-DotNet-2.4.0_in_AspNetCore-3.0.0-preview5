using GraphQL.EntityFramework;
using GraphQL.Types;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class ProductGraph :
    EfObjectGraphType<AppDbContext, Product>
    {
        public ProductGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.ProductId);     //Field("ids", x => x.ProductId);
            Field(x => x.Name).Description("Name of Product");
            Field(x => x.ProductNumber);
            Field(x => x.MakeFlag, nullable: true);
            Field(x => x.FinishedGoodsFlag, nullable: true);
            Field(x => x.Color, nullable: true);
            //Field(x => x.SafetyStockLevel, type: typeof(ShortGraphType));     // Known problem with GraphQl-DotNet and ShortGraphType
            //Field(x => x.ReorderPoint, type: typeof(ShortGraphType));         // Known problem with GraphQl-DotNet and ShortGraphType
            Field(x => x.StandardCost, type: typeof(DecimalGraphType));
            Field(x => x.ListPrice, type: typeof(DecimalGraphType));
            Field(x => x.Size, nullable: true);
            Field(x => x.SizeUnitMeasureCode).Description("Property of UnitMeasureType --> InverseProperty");
            Field(x => x.WeightUnitMeasureCode).Description("Property of UnitMeasureType --> InverseProperty");
            Field(x => x.Weight, nullable: true, type: typeof(DecimalGraphType));
            Field(x => x.DaysToManufacture);
            Field(x => x.ProductLine);
            Field(x => x.Class);
            Field(x => x.Style);
            Field(x => x.SellStartDate);
            Field(x => x.SellEndDate, nullable: true);
            Field(x => x.DiscontinuedDate, nullable: true);
            Field(x => x.Rowguid, type: typeof(IdGraphType));
            Field(x => x.ModifiedDate);
            AddNavigationListField(
                name: "productReview",
                resolve: context => context.Source.ProductReview);
            AddNavigationConnectionField(
                name: "productReviewConnection",
                resolve: context => context.Source.ProductReview,
                includeNames: new[] { "ProductReview" });
            AddNavigationListField(
                name: "transactionHistory",
                resolve: context => context.Source.TransactionHistory);
            AddNavigationConnectionField(
                name: "transactionHistoryConnection",
                resolve: context => context.Source.TransactionHistory,
                includeNames: new[] { "TransactionHistory" });
            AddNavigationField(
                name: "ProductSubcategory",
                resolve: context => context.Source.ProductSubcategory);

            // ###############
            // Original Types from GraphQL for .NET
            // ###############
            ////Field<ProductModelType>(nameof(Product.ProductModel)/*, nullable: true*/);
            ////Field<UnitMeasureType>(nameof(Product.SizeUnitMeasureCode)/*, nullable: true*/);
            ////Field<UnitMeasureType>(nameof(Product.WeightUnitMeasureCode)/*, nullable: true*/);
            
        }
    }
}
