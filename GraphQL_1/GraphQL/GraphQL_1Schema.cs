using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.GraphQL
{
    public class GraphQL_1Schema : Schema
    {
        public GraphQL_1Schema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ProductQuery>();
        }
    }
}
