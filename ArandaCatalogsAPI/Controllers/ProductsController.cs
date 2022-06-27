using ArandaCatalogs.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

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
        [Route("Api/Products/GetProducts")]
        [HttpPost]
        public IEnumerable<ProductModel> GetProducts([FromBody] FilterProducts filters)
        {
            return ProductsService.GetProducts(filters);
        }

        [Route("Api/Products/AddNewProduct")]
        [HttpPut]
        public Task AddNewProduct(ProductModel request)
        {
            ProductsService.AddNewProduct(request);
            return Task.CompletedTask;
        }

        [Route("Api/Products/UpdateProduct")]
        [HttpPost]
        public Task UpdateProduct(ProductModel request)
        {
            ProductsService.UpdateProduct(request);
            return Task.CompletedTask;
        }

        // DELETE: api/Products/5
        [Route("Api/Products/Delete/{id}")]
        [HttpPost]
        public Task Delete(Guid id)
        {
            ProductsService.DeleteProduct(id);
            return Task.CompletedTask;
        }
    }
}
