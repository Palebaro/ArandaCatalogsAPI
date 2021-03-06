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
        /// <summary>
        /// Gets registered categories
        /// </summary>
        /// <returns></returns>
        IEnumerable<CategoryModel> GetCategorys();
        /// <summary>
        /// Add new categories
        /// </summary>
        /// <param name="request"></param>
        void AddNewCategory(string request);
        /// <summary>
        /// Remove categories
        /// </summary>
        /// <param name="id"></param>
        void DeleteCategory(Guid id);
    }
}
