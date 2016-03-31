using ProductPricing.Core.Data.Repositories;
using ProductPricing.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IDbContext _context;
        private readonly IDbSet<Product> _dbEntitySet;

        public ProductRepository(IDbContext context) : base(context)
        {
            _context = context;
            _dbEntitySet = _context.Set<Product>();
        }

        public async Task<List<Product>> GetAllWithIncludeAsync()
        {
            return await _dbEntitySet.Include("Supplier").Where(t => !t.IsDeleted).ToListAsync();
        }

        public async Task<List<Product>> GetBySupplierIdAsync(long supplierId)
        {
            return await _dbEntitySet.Include("Supplier").Where(t => t.SupplierId == supplierId && !t.IsDeleted).ToListAsync();
        }
    }
}