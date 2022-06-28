using ArandaCatalogs.Domain.Interfaces;
using ArandaCatalogs.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaCatalogs.Domain.Services
{
    public class ProductsService : IProductsService
    {
        IProductsRepository ProductsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            ProductsRepository = productsRepository;
        }
        /// <summary>
        ///  Add new products
        /// </summary>
        /// <param name="request"></param>
        public void AddNewProduct(ProductModel request)
        {
            ProductsRepository.AddNewProduct(request);
        }
        /// <summary>
        /// Updates registered products
        /// </summary>
        /// <param name="request"></param>
        public void UpdateProduct(ProductModel request)
        {
            ProductsRepository.UpdateProduct(request);
        }
        /// <summary>
        /// Gets products registered by search filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetProducts(FilterProducts filters)
        {
            return ProductsRepository.GetProducts(filters);
        }
        /// <summary>
        /// Remove products
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(Guid id)
        {
            ProductsRepository.DeleteProduct(id);
        }
    }
}
