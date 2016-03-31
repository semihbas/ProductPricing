using Microsoft.Owin;
using Owin;
using ProductPricing.Web.Capsule;
using ProductPricing.Web.Mapping;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(ProductPricing.Web.Startup))]

namespace ProductPricing.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            ConfigureAuth(app);

            var mappingDefinitions = new MappingDefinitions();
            mappingDefinitions.Initialise();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            WebApiConfig.Register(config);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            new WebCapsule().Initialise(config);

            app.UseWebApi(config);
        }
    }
}