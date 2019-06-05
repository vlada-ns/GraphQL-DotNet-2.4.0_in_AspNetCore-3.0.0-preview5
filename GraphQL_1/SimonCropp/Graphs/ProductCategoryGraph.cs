using GraphQL.EntityFramework;
using GraphQL.Types;
using GraphQL_1.Data;
using GraphQL_1.Models;

namespace GraphQL_1.SimonCropp.Graphs
{
    public class ProductCategoryGraph :
    EfObjectGraphType<AppDbContext, ProductCategory>
    {
        public ProductCategoryGraph(IEfGraphQLService<AppDbContext> graphQlService) :
            base(graphQlService)
        {
            Field(x => x.ProductCategoryId);
            Field(x => x.Name).Description("Name of ProductCategory");
            Field(x => x.Rowguid, type: typeof(IdGraphType)).Description("Rowguid of the ProductCategory");
            Field(x => x.ModifiedDate).Description("ModifiedDate of ProductCategory");
            AddNavigationListField(
                name: "productSubcategories",
                resolve: context => context.Source.ProductSubcategory);
            AddNavigationConnectionField(
                name: "productSubcategoriesConnection",
                resolve: context => context.Source.ProductSubcategory,
                includeNames: new[] { "ProductSubcategory" });
        }
    }
}
