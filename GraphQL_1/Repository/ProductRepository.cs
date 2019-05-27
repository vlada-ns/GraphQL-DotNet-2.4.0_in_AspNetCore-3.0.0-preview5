using GraphQL_1.Data;
using GraphQL_1.Interfaces;
using GraphQL_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.Repository
{
    public class ProductRepository : IProductRepository
    {
        //private Models.DbContext.AppContext db = new Models.DbContext.AppContext();
        private AppDbContext _db;
        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task<IList<Product>> GetAll()
        {
            return Task.FromResult<IList<Product>>(new List<Product>(_db.Product));
        }
    }
}
