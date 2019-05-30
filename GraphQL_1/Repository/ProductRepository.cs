using GraphQL_1.Data;
using GraphQL_1.Interfaces;
using GraphQL_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public async Task<IList<Product>> GetProductsAsync(List<int> ids = null)
        {
            var tmp =  ids == null || !ids.Any()
                ? await Task.FromResult(_db.Product
                    .Include(x => x.TransactionHistory)
                    .Include(x=>x.ProductSubcategory)
                    .ToList())
                : await Task.FromResult(_db.Product/*.Include(x => x.TransactionHistory)*/.Where(product => ids.Contains(product.ProductId)).ToList());
            return tmp;
        }
        public IQueryable<Product> GetAll(string orderBy = "", int id = -411)
        {
            if (id == -411)
            {
                //return _db.Product.Include(x=>x.TransactionHistory).ToList();
                if(orderBy == "desc")
                {
                    return _db.Product.OrderByDescending(x=>x.ProductId);
                }
                return _db.Product;
            }
            return _db.Product.Where(x=>x.ProductId == id);
        }

        public IIncludableQueryable<Product, ICollection<TransactionHistory>> GetQuery()
        {
            return _db
                 .Product
                 .Include(x => x.TransactionHistory);
        }

        //public async Task<List<Department>> GetDepartmentsAsync(List<int> Ids = null)
        //{
        //    return Ids == null || !Ids.Any()
        //        ? await Task.FromResult(InMemoryData.Departments)
        //        : await Task.FromResult(InMemoryData.Departments.Where(department => Ids.Contains(department.Id)).ToList());
        //}



        //public IIncludableQueryable<Reservation, Guest> GetQuery()
        //{
        //    return _myHotelDbContext
        //         .Reservations
        //         .Include(x => x.Room)
        //         .Include(x => x.Guest);
        //}
        //public IIncludableQueryable<Product, TransactionHistory> GetQuery()
        //{
        //    return _db
        //         .Product
        //         .Include(x => x.TransactionHistory);
        //}
    }
}
