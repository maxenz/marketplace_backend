using System.Web.Http;
using System.Web.Mvc;
using Shaman.MarketPlace.Web.App_Start;

namespace Shaman.MarketPlace.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
        }
    }
}
