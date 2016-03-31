using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Data.Configurations
{
    public class ProductConfiguration : EntityBaseConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(c => c.Name).IsRequired();
        }
    }
}