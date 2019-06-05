using GraphQL.EntityFramework;
using GraphQL.Types;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class TransactionHistoryGraph :
    EfObjectGraphType<AppDbContext, TransactionHistory>
    {
        public TransactionHistoryGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.TransactionId);
            Field(x => x.ReferenceOrderId);
            Field(x => x.ReferenceOrderLineId);
            Field(x => x.TransactionDate);
            Field(x => x.TransactionType);
            Field(x => x.Quantity);
            Field(x => x.ActualCost);
            Field(x => x.ModifiedDate);
            AddNavigationField(
                name: "product",
                resolve: context => context.Source.Product);
        }
    }
}
