using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductPricing.Core.Entities
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            DateCreated = DateTime.Now;
            Products = new List<Product>();
        }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}