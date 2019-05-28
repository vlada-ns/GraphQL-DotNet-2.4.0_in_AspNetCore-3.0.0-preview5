using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.Interfaces
{
    interface IProductSubcategory
    {
        Task<IList<ProductSubcategory>> GetAllAsync(List<int> ids = null);
    }
}
