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

        public void AddNewProduct(ProductModel request)
        {
            ProductsRepository.AddNewProduct(request);
        }

        public IEnumerable<ProductModel> GetProducts(FilterProducts filters)
        {
            return ProductsRepository.GetProducts(filters);
        }
    }
}
