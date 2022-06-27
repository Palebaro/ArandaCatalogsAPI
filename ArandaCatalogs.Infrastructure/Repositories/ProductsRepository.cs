using ArandaCatalogs.Domain.Interfaces;
using ArandaCatalogs.Domain.ModelsDomain;
using ArandaCatalogs.Infrastructure.Data;
using ArandaCatalogs.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaCatalogs.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        ArandaCatalogsDB DbContext;

        public ProductsRepository(ArandaCatalogsDB dbContext)
        {
            DbContext = dbContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetProducts(FilterProducts filters)
        {
            var result = (from c in DbContext.Products
                         where c.Name == filters.Name 
                         || c.Description == filters.Description
                         || c.Category_Id == filters.CategoryId
                         select new ProductModel
                         {
                             Id = c.Id,
                             Name = c.Name,
                             Description = c.Description,
                             Category_Id = c.Category_Id,
                             Image = c.Image
                         })
                         .Take(100000)
                         .ToList();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddNewProduct(ProductModel request)
        {
            DbContext.Products.Add(new Products
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Category_Id = request.Category_Id,
                Image = request.Image
            });
            DbContext.SaveChanges();
            return Task.CompletedTask;
        }

    }
}
