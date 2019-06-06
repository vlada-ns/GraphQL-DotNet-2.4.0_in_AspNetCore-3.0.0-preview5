using GraphQL.EntityFramework;
using GraphQL.Types;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class ProductSubcategoryGraph :
    EfObjectGraphType<AppDbContext, ProductSubcategory>
    {
        public ProductSubcategoryGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.ProductSubcategoryId);
            Field(x => x.Name).Description("Name of ProductSubcategory");
            Field(x => x.Rowguid, type: typeof(IdGraphType)).Description("Rowguid of the ProductSubcategory");
            Field(x => x.ModifiedDate).Description("ModifiedDate of ProductSubcategory");
            AddNavigationListField(
                name: "product",
                resolve: context => context.Source.Product);
            AddNavigationConnectionField(
                name: "productConnection",
                resolve: context => context.Source.Product,
                includeNames: new[] { "Product" });
            AddNavigationField(
                name: "productCategory",
                resolve: context => context.Source.ProductCategory);
        }
    }
}
