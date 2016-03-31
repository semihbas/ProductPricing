using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Dto.Dtos
{
    public class ProductDto : ProductEditDto
    {
        public DateTime DateCreated { get; set; }

        public SupplierDto Supplier { get; set; }
    }
}