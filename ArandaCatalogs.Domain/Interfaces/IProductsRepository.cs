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
        Task AddNewProduct(ProductModel request);
        IEnumerable<ProductModel> GetProducts(FilterProducts filters);
        Task DeleteProduct(Guid id);
        Task UpdateProduct(ProductModel request);
    }
}
