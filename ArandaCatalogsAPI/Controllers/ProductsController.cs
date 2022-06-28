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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Api/Products/AddNewProduct")]
        [HttpPut]
        public Task AddNewProduct(ProductModel request)
        {
            ProductsService.AddNewProduct(request);
            return Task.CompletedTask;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Api/Products/UpdateProduct")]
        [HttpPut]
        public Task UpdateProduct(ProductModel request)
        {
            ProductsService.UpdateProduct(request);
            return Task.CompletedTask;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Api/Products/Delete/{id}")]
        [HttpDelete]
        public Task Delete(Guid id)
        {
            ProductsService.DeleteProduct(id);
            return Task.CompletedTask;
        }
    }
}
