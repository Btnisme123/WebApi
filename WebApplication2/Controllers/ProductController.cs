using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class ProductController : ApiController
    {
        DBShopDataContext dbContext =new DBShopDataContext();

        [HttpGet]
        public List<Product> GetProductList()
        {
            return dbContext.Products.ToList();
        }

        [HttpGet]
        public Product GetProduct(int id)
        {
            return dbContext.Products.FirstOrDefault(x => x.ID == id);
        }

    }
}
