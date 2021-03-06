﻿using System.Web.Http;
using System.Web.Mvc;
using Shaman.MarketPlace.Web.App_Start;
using Shaman.MarketPlace.Data.Configuration.EntityFramework;
using Shaman.MarketPlace.Data.Configuration;

namespace Shaman.MarketPlace.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //AreaRegistration.RegisterAllAreas();
            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling =
            //    Newtonsoft.Json.PreserveReferencesHandling.All;
            using (var ctx = new MarketPlaceDbContext())
            {
                new DbInitializer().InitializeDatabase(ctx);
            }

        }
    }
}
