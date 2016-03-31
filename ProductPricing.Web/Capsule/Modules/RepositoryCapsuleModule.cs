using Autofac;
using ProductPricing.Core.Data.Repositories;
using ProductPricing.Data.Repositories;
using ProductPricing.Web.References;

namespace ProductPricing.Web.Capsule.Modules
{
    public class RepositoryCapsuleModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ReferencedAssemblies.Repositories).
                Where(_ => _.Name.EndsWith("Repository")).
                AsImplementedInterfaces().
                InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();
        }
    }
}