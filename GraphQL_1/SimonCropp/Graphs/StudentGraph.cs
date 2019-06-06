using GraphQL.EntityFramework;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class StudentGraph :
    EfObjectGraphType<AppDbContext, Student>
    {
        public StudentGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.StudentId);
            Field(x => x.Name);
            AddNavigationField(
                name: "grade",
                resolve: context => context.Source.Grade);
        }
    }
}
