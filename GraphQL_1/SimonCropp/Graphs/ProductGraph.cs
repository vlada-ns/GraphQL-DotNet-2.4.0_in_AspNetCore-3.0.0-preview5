using GraphQL.EntityFramework;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class ProductGraph :
    EfObjectGraphType<AppDbContext, Product>
    {
        public ProductGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.ProductId);
            Field(x => x.Name);
            //AddNavigationListField(
            //    name: "employees",
            //    resolve: context => context.Source.Employees);
            //AddNavigationConnectionField(
            //    name: "employeesConnection",
            //    resolve: context => context.Source.Employees,
            //    includeNames: new[] { "Employees" });
        }
    }
}
