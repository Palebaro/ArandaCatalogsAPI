using ArandaCatalogs.Domain.Interfaces;
using ArandaCatalogs.Domain.ModelsDomain;
using ArandaCatalogs.Infrastructure.Data;
using ArandaCatalogs.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            try
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
                              .OrderBy(x => x.Name)
                             .Take(100000)
                             .ToList();
             return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddNewProduct(ProductModel request)
        {
            try
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
            catch (Exception e)
            {
                throw e;
            }

        }
        public Task UpdateProduct(ProductModel request)
        {
            try
            {
                var result = DbContext.Products.SingleOrDefault(c => c.Id == request.Id);

                result.Name = request.Name;
                result.Description = request.Description;
                result.Category_Id = request.Category_Id;
                result.Image = request.Image;

                DbContext.Entry(result).State = EntityState.Modified;
                DbContext.SaveChanges();
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Task DeleteProduct(Guid id)
        {
            try
            {
                var product = DbContext.Products.Single(c => c.Id == id);
                DbContext.Products.Remove(product);
                DbContext.SaveChanges();
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
