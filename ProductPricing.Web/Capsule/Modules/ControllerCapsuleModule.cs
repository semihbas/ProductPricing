using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace ProductPricing.Web.Capsule.Modules
{
    public class ControllerCapsuleModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register the MVC Controllers
            //builder.RegisterControllers(Assembly.Load("ProductPricing.Web"));

            // Register the Web API Controllers
            //builder.RegisterApiControllers(Assembly.GetCallingAssembly());
            builder.RegisterApiControllers(Assembly.Load("ProductPricing.Web"));
        }
    }
}