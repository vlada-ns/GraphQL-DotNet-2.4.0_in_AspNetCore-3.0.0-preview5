using GraphQL_1.Data;

namespace GraphQL_1.GraphQL
{
    public class ContextFactory
    {
        public AppDbContext BuildContext() => DbContextBuilder.BuildDbContext();
    }
}
