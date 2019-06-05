using GraphQL;

namespace GraphQL_1.SimonCropp
{
    public class Schema : global::GraphQL.Types.Schema
    {
        public Schema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<Query>();
            //Subscription = resolver.Resolve<Subscription>();
        }
    }
}
