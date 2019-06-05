using GraphQL_1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.SimonCropp
{
    public class ContextFactory
    {
        public AppDbContext BuildContext() => DbContextBuilder.BuildDbContext();
    }
}
