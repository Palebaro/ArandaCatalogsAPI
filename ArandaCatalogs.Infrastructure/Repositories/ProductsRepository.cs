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
        /// Gets products registered by search filters
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetProducts(FilterProducts filters)
        {
            try
            {
                var result = (from p in DbContext.Products
                              join c in DbContext.Category on p.Category_Id equals c.Id
                              where  p.Name == filters.Name
                                     || p.Description == filters.Description
                                     || p.Category_Id == filters.CategoryId
                              select new ProductModel
                              {
                                  Id = p.Id,
                                  Name = p.Name,
                                  Description = p.Description,
                                  CategoryId = p.Category_Id,
                                  Image = p.Image,
                                  CategoryName = c.Category_Name
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
        ///  Add new products
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
                    Category_Id = request.CategoryId,
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
        /// <summary>
        /// Updates registered products
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateProduct(ProductModel request)
        {
            try
            {
                var result = DbContext.Products.SingleOrDefault(c => c.Id == request.Id);

                result.Name = request.Name;
                result.Description = request.Description;
                result.Category_Id = request.CategoryId;
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
        /// <summary>
        /// Remove products
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
