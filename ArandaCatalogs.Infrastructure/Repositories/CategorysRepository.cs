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
    public class CategorysRepository : ICategoryRepository
    {

        ArandaCatalogsDB DbContext;

        public CategorysRepository(ArandaCatalogsDB dbContext)
        {
            DbContext = dbContext;
        }
        /// <summary>
        /// Gets registered categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryModel> GetCategorys()
        {
            try
            {
                var result = (from c in DbContext.Category
                              select new CategoryModel
                              {
                                  Id = c.Id,
                                  CategoryName = c.Category_Name
                              }).ToList();

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task AddNewCategory(string request)
        {
            try
            {
                DbContext.Category.Add(new Category
                {
                    Id = Guid.NewGuid(),
                    Category_Name = request
                });
                DbContext.SaveChanges();
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task DeleteCategory(Guid id)
        {
            try
            {
                var category = DbContext.Category.Single(c => c.Id == id);
                DbContext.Category.Remove(category);
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
