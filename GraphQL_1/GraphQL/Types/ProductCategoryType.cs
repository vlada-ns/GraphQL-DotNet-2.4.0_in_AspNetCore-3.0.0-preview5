using GraphQL.Types;
using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL.Types
{
    public class ProductCategoryType : ObjectGraphType<ProductCategory>
    {
        public ProductCategoryType()
        {
            Field(x => x.ProductCategoryId);
            Field(x => x.Name).Description("Name of ProductCategory");
            Field(x => x.Rowguid, type: typeof(IdGraphType)).Description("Rowguid of the ProductCategory");
            Field(x => x.ModifiedDate).Description("ModifiedDate of ProductCategory");
            Field<ListGraphType<ProductSubcategoryType>>(nameof(ProductCategory.ProductSubcategory));
        }
    }
}
