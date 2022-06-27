using ArandaCatalogs.Domain.Interfaces;
using ArandaCatalogs.Domain.ModelsDomain;
using ArandaCatalogs.Domain.Services;
using ArandaCatalogs.Infrastructure.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ArandaCatalogsAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICategoryRepository, CategorysRepository>();
            container.RegisterType<ICategorysService, CategoysService>();
            container.RegisterType<IProductsRepository, ProductsRepository>();
            container.RegisterType<IProductsService, ProductsService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}