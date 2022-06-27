using ArandaCatalogs.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaCatalogs.Domain.ModelsDomain
{
    public interface IProductsService
    {
        void AddNewProduct(ProductModel request);
        IEnumerable<ProductModel> GetProducts(FilterProducts filters);
        void DeleteProduct(Guid id);
        void UpdateProduct(ProductModel request);
    }
}
