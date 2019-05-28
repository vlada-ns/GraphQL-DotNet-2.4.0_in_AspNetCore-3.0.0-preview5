using GraphQL_1.Data;
using GraphQL_1.Interfaces;
using GraphQL_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_1.Repository
{
    public class ProductSubcategoryRepository : IProductSubcategory
    {
        private AppDbContext _db;
        public ProductSubcategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IList<ProductSubcategory>> GetAllAsync(List<int> ids = null)
        {
            var tmp = ids == null || !ids.Any()
                ? await Task.FromResult(_db.ProductSubcategory
                    .Include(x => x.Product)
                    .Include(x=>x.ProductCategory)
                    .ToList())
                : await Task.FromResult(_db.ProductSubcategory/*.Include(x => x.TransactionHistory)*/.Where(ps => ids.Contains(ps.ProductSubcategoryId)).ToList());
            return tmp;
        }

        public IQueryable<ProductSubcategory> GetAll(int id = -1)
        {
            if (id == -1)
            {
                //return _db.Product.Include(x=>x.TransactionHistory).ToList();
                return _db.ProductSubcategory;
            }
            return _db.ProductSubcategory.Where(x => x.ProductSubcategoryId == id);
        }
    }
}
