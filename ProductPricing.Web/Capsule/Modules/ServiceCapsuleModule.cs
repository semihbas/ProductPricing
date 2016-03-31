using Autofac;
using ProductPricing.Core.Services;
using ProductPricing.Services.Services;
using ProductPricing.Web.References;

namespace ProductPricing.Web.Capsule.Modules
{
    public class ServiceCapsuleModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ReferencedAssemblies.Services).
                Where(_ => _.Name.EndsWith("Service")).
                AsImplementedInterfaces().
                InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BaseService<>)).As(typeof(IService<>)).InstancePerDependency();
        }
    }
}