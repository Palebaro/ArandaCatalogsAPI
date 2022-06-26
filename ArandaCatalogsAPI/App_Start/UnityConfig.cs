using ArandaCatalogs.Domain.Interfaces;
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

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICategoryRepository, CategorysRepository>();
            container.RegisterType<ICategorysService, CategoysService>();
            //container.RegisterType<ICategorysService, CategoysService>();
            //container.RegisterType<ICategorysService, CategoysService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}