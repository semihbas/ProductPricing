using System.Reflection;

namespace ProductPricing.Web.References
{
    public static class ReferencedAssemblies
    {
        public static Assembly Services
        {
            get { return Assembly.Load("ProductPricing.Services"); }
        }

        public static Assembly Repositories
        {
            get { return Assembly.Load("ProductPricing.Data"); }
        }

        public static Assembly Dto
        {
            get
            {
                return Assembly.Load("ProductPricing.Dto");
            }
        }

        public static Assembly Domain
        {
            get
            {
                return Assembly.Load("ProductPricing.Core");
            }
        }
    }
}