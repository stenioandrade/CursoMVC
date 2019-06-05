using System.Web.Http;
using EP.CursoMvc.Application.AutoMapper;

namespace EP.CursoMvc.Services.REST.ClienteAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
