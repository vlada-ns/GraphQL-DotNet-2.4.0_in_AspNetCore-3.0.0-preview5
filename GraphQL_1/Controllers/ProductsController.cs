using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_1.Models;
using GraphQL_1.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphQL_1.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //[HttpGet("[action]")]
        //public IEnumerable<Product> List()
        //{
        //    return _productRepository.GetAll();
        //}
        //[HttpGet("[action]")]
        //public async Task<IList<Product>> List()
        //{
        //    return await _productRepository.GetProductsAsync();
        //}

        [HttpGet("[action]")]
        public async Task<IList<Product>> List(List<int> ids)
        {
            return await _productRepository.GetProductsAsync(ids);
        }

        //// GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
