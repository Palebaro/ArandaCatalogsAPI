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
        public IEnumerable<CategoryModel> GetCategorys()
        {
            var result = DbContext.Category.Select(c => new CategoryModel
            {
                Id = c.Id,
                CategoryName = c.Category_Name
            });
            return result;
        }

        public Task AddNewCategory(string request)
        {
            DbContext.Category.Add(new Category
            {
                Id = Guid.NewGuid(),
                Category_Name = request
            });
            DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteCategory(Guid id)
        {
            var category = DbContext.Category.Single(c => c.Id == id);
            DbContext.Category.Remove(category);
            DbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
