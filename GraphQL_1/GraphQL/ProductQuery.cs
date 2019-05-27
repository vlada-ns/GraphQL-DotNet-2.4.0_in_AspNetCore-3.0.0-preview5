using GraphQL.Types;
using GraphQL_1.GraphQL.Types;
using GraphQL_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(ProductRepository productRepository)
        {
            Field<ListGraphType<ProductType>>("products",
                resolve: context => productRepository.GetAll());
        }
    }
}
