using ProductPricing.Core.Data;
using ProductPricing.Core.Data.Repositories;
using ProductPricing.Core.Entities;
using ProductPricing.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPricing.Services.Services
{
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}