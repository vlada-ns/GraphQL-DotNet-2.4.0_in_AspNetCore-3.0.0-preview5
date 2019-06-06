using GraphQL.EntityFramework;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class HouseGraph :
    EfObjectGraphType<AppDbContext, House>
    {
        public HouseGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.HouseId);
            Field(x => x.Name);
            AddNavigationListField(
                name: "windows",
                resolve: context => context.Source.Windows);
            AddNavigationConnectionField(
                name: "windowsConnection",
                resolve: context => context.Source.Windows,
                includeNames: new[] { "Windows" });
        }
    }
}
