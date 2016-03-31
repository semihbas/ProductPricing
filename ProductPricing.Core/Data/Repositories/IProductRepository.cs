using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Core.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllWithIncludeAsync();

        Task<List<Product>> GetBySupplierIdAsync(long supplierId);
    }
}