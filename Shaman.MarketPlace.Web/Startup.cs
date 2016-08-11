using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Shaman.MarketPlace.Data.Configuration;
using Shaman.MarketPlace.Data.Configuration.EntityFramework;
using Shaman.MarketPlace.Web.App_Start;
using Shaman.MarketPlace.Web.Providers;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Shaman.MarketPlace.Web.Startup))]
namespace Shaman.MarketPlace.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

    }
}