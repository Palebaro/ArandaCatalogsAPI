using ArandaCatalogs.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaCatalogs.Domain.Interfaces
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Add new products
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task AddNewProduct(ProductModel request);
        /// <summary>
        /// Gets products registered by search filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        IEnumerable<ProductModel> GetProducts(FilterProducts filters);
        /// <summary>
        /// Remove products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProduct(Guid id);
        /// <summary>
        /// Updates registered products
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UpdateProduct(ProductModel request);
    }
}
