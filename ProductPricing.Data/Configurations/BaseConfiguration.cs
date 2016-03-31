using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Data.Configurations
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntity
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.Id);
        }
    }
}