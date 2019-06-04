using GraphQL.EntityFramework;
using GraphQL_1.Data;
using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL.Graphs
{
    public class ProductGraph : EfObjectGraphType<AppDbContext, Product>
    {
        public ProductGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.ProductId);
            Field(x => x.Name);
            //AddNavigationListField(
            //    name: "productReviews",
            //    resolve: context => context.Source.ProductReview);
            //AddNavigationConnectionField(
            //    name: "productReviewsConnection",
            //    resolve: context => context.Source.ProductReview,
            //    includeNames: new[] { "ProductReviews" });
        }
    }
}
