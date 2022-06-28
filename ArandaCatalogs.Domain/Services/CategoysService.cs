using ArandaCatalogs.Domain.Interfaces;
using ArandaCatalogs.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaCatalogs.Domain.Services
{
    public class CategoysService : ICategorysService
    {
        ICategoryRepository CategoryRepository;

        public CategoysService(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        /// <summary>
        /// Gets registered categories
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryModel> GetCategorys()
        {
            return CategoryRepository.GetCategorys();
        }
        /// <summary>
        /// Add new categories
        /// </summary>
        /// <param name="request"></param>
        public void AddNewCategory(string request)
        {
            CategoryRepository.AddNewCategory(request);
        }
        /// <summary>
        /// Remove categories
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCategory(Guid id)
        {
            CategoryRepository.DeleteCategory(id);
        }
    }
}
