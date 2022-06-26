using ArandaCatalogs.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaCatalogs.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> GetCategorys();
        Task AddNewCategory(string request);
        Task DeleteCategory(Guid id);
    }
}
