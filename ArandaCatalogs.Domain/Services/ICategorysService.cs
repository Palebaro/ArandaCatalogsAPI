using ArandaCatalogs.Domain.ModelsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaCatalogs.Domain.Services
{
    public interface ICategorysService
    {
        IEnumerable<CategoryModel> GetCategorys();
        void AddNewCategory(string request);
        void DeleteCategory(Guid id);
    }
}
