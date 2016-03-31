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
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _productRepository = productRepository;
        }

        public Task<List<Product>> GetAllWithIncludeAsync()
        {
            return _productRepository.GetAllWithIncludeAsync();
        }

        public Task<List<Product>> GetBySupplierIdAsync(long supplierId)
        {
            return _productRepository.GetBySupplierIdAsync(supplierId);
        }
    }
}