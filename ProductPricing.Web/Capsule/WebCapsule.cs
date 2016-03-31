using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ProductPricing.Core.Data;
using ProductPricing.Core.Logging;
using ProductPricing.Data;
using ProductPricing.Logging.Logging;
using ProductPricing.Web.Capsule.Modules;
using System.Web.Http;
using System.Web.Mvc;

//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebCapsule), "Initialise")]
namespace ProductPricing.Web.Capsule
{
    public class WebCapsule
    {
        public void Initialise(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterFilterProvider();

            const string nameOrConnectionString = "name=ProductPricingDbConnection";
            builder.Register<IDbContext>(b =>
            {
                var logger = b.ResolveOptional<ILogger>();
                var context = new ProductPricingDbContext(nameOrConnectionString, logger);
                return context;
            }).InstancePerLifetimeScope();

            builder.Register(b => NLogLogger.Instance).SingleInstance();

            builder.RegisterModule<RepositoryCapsuleModule>();
            builder.RegisterModule<ServiceCapsuleModule>();
            builder.RegisterModule<ControllerCapsuleModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}