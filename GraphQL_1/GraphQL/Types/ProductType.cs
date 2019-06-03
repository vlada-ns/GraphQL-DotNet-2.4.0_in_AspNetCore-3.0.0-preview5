using GraphQL.Types;
using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
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
            Field<ProductSubcategoryType>(nameof(Product.ProductSubcategory)/*, nullable: true*/);
            //Field<ProductModelType>(nameof(Product.ProductModel)/*, nullable: true*/);
            //Field<UnitMeasureType>(nameof(Product.SizeUnitMeasureCode)/*, nullable: true*/);
            //Field<UnitMeasureType>(nameof(Product.WeightUnitMeasureCode)/*, nullable: true*/);
            Field<ListGraphType<ProductReviewType>>(nameof(Product.ProductReview));
            Field<ListGraphType<TransactionHistoryType>>(nameof(Product.TransactionHistory));
        }
    }
}
