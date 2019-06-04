using GraphQL.EntityFramework;
using GraphQL_1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL
{
    public class Query : QueryGraphType<AppDbContext>
    {
        public Query(IEfGraphQLService<AppDbContext> graphQlService) : base(graphQlService)
        {
            AddQueryField(
                name: "products",
                resolve: context => context.DbContext.Product);     // Object reference not set to an instance of an object.

            AddSingleField(
                resolve: context => context.DbContext.Product,
                name: "product");

            AddQueryConnectionField(
                name: "productsConnection",
                resolve: context => context.DbContext.Product);
        }
    }
}
