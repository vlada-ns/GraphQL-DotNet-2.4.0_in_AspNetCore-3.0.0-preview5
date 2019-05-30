using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetProductsAsync(List<int> Ids = null);
        IQueryable<Product> GetAll(string orderBy, int id);
    }
}
