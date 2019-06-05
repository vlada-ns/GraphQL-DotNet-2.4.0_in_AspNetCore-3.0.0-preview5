using GraphQL.EntityFramework;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class ProductReviewGraph :
    EfObjectGraphType<AppDbContext, ProductReview>
    {
        public ProductReviewGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.ProductReviewId);
            Field(x => x.ReviewerName);
            Field(x => x.ReviewDate);
            Field(x => x.EmailAddress);
            Field(x => x.Rating);
            Field(x => x.Comments);
            Field(x => x.ModifiedDate);
            AddNavigationField(
                name: "product",
                resolve: context => context.Source.Product);
        }
    }
}
