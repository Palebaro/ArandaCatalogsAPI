using System.Web.Http;
using WebActivatorEx;
using ArandaCatalogsAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ArandaCatalogsAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "API Aranda Software Catalogo ")
                        .Description("Catalogo Web API")
                            .TermsOfService("Términos de servicio.")
                            .Contact(x => x
                                .Name("Aranda Software")
                                .Url("")
                                .Email("info@test.net"))
                            .License(x => x
                                .Name("Licencia")
                                .Url(""));

                        c.PrettyPrint();
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }
    }
}
