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
            AddSingleField(
                resolve: context => context.DbContext.Product,
                name: "product");
            AddQueryField(
                name: "products",
                resolve: context => context.DbContext.Product);
            AddQueryConnectionField(
                name: "products",
                resolve: context => context.DbContext.Product);
        }
    }
}
