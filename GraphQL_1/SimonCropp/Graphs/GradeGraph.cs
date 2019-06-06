using GraphQL.EntityFramework;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class GradeGraph :
    EfObjectGraphType<AppDbContext, Grade>
    {
        public GradeGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.GradeId);
            Field(x => x.GradeName);
            AddNavigationListField(
                name: "students",
                resolve: context => context.Source.Students);
        }
    }
}
