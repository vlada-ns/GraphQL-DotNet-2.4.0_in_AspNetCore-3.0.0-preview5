using GraphQL.Types;
using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL.Types
{
    public class ProductSubcategoryType : ObjectGraphType<ProductSubcategory>
    {
        public ProductSubcategoryType()
        {
            Field(x => x.ProductSubcategoryId);
            Field(x => x.Name).Description("Name of ProductSubcategory");
            Field(x => x.Rowguid, type: typeof(IdGraphType)).Description("Rowguid of the ProductSubcategory");
            Field(x => x.ModifiedDate).Description("ModifiedDate of ProductSubcategory");
            Field<ProductCategoryType>(nameof(ProductSubcategory.ProductCategory));
            Field<ListGraphType<ProductType>>(nameof(ProductSubcategory.Product));
        }
    }
}
