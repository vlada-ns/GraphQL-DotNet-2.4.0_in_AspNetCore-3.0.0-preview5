using GraphQL;

namespace GraphQL_1.GraphQL
{
    public class Schema : global::GraphQL.Types.Schema
    {
        public Schema(IDependencyResolver resolver) :
            base(resolver)
        {
            //Query = resolver.Resolve<AdventureWorksQuery>();
            //Subscription = resolver.Resolve<Subscription>();
        }
    }
}
