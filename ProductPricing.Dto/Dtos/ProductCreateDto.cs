using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Dto.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }

        public long SupplierId { get; set; }
        public SupplierDto Supplier { get; set; }

        public decimal Price { get; set; }
    }
}