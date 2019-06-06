using GraphQL.EntityFramework;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class WindowGraph :
    EfObjectGraphType<AppDbContext, Window>
    {
        public WindowGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.WindowId);
            Field(x => x.Name);
            AddNavigationField(
                name: "house",
                resolve: context => context.Source.House);
        }
    }
}
