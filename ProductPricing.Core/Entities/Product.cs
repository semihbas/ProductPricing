using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            DateCreated = DateTime.Now;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public long SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
    }
}