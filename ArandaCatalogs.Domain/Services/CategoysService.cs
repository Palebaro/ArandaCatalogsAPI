using ArandaCatalogs.Domain.Interfaces;
using ArandaCatalogs.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaCatalogs.Domain.Services
{
    public class CategoysService :ICategorysService
    {
        ICategoryRepository CategoryRepository;

        public CategoysService(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryModel> GetCategorys()
        {
            return CategoryRepository.GetCategorys();
        }

        public void AddNewCategory(string request)
        {
            CategoryRepository.AddNewCategory(request);
        }

        public void DeleteCategory(Guid id)
        {
            CategoryRepository.DeleteCategory(id);
        }
    }
}
