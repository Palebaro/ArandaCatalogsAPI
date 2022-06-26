using ArandaCatalogs.Domain.ModelsDomain;
using ArandaCatalogs.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ArandaCatalogsAPI.Controllers
{
    public class CategorysController : ApiController
    {

        ICategorysService CategorysService;
        
        public CategorysController(ICategorysService sategorysService)
        {
            CategorysService = sategorysService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("Api/GetCategorys")]
        [HttpGet]
        public IEnumerable<CategoryModel> GetCategorys()
        {
            return CategorysService.GetCategorys();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("Api/AddNewCategory")]
        [HttpPut]
        public Task AddNewCategory(string request)
        {
            CategorysService.AddNewCategory(request);
            return Task.CompletedTask;
        }

        [Route("Api/DeleteCategory/{id}")]
        [HttpDelete]
        public Task DeleteCategory(Guid id)
        {
            CategorysService.DeleteCategory(id);
            return Task.CompletedTask;
        }
    }
}
