using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Data.Configurations
{
    public class SupplierConfiguration : EntityBaseConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            Property(c => c.Name).IsRequired();
        }
    }
}