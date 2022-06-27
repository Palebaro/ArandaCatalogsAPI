using ArandaCatalogs.Domain.ModelsDomain;
using ArandaCatalogs.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ArandaCatalogsAPI.Controllers
{
    public class ProductsController : ApiController
    {

        IProductsService ProductsService;

        public ProductsController(IProductsService productsService)
        {
            ProductsService = productsService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [Route("Api/GetProducts")]
        [HttpPost]
        public IEnumerable<ProductModel> GetProducts([FromBody] FilterProducts filters)
        {
            return ProductsService.GetProducts(filters);
        }

        [Route("Api/AddNewProduct")]
        [HttpPut]
        public Task AddNewProduct(ProductModel request)
        {
            ProductsService.AddNewProduct(request);
            return Task.CompletedTask;
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
