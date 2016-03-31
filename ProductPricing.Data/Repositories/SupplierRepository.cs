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
    public class SupplierRepository : BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IDbContext context) : base(context)
        {
        }
    }
}