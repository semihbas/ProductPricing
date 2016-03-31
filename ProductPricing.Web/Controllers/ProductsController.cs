using AutoMapper;
using Microsoft.AspNet.Identity;
using ProductPricing.Core.Entities;
using ProductPricing.Core.Services;
using ProductPricing.Dto.Dtos;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ProductPricing.Web.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProducts()
        {
            List<Product> products = await _productService.GetAllWithIncludeAsync();

            List<ProductDto> productDtos = new List<ProductDto>();

            Mapper.Map(products, productDtos);

            return Ok(productDtos);
        }

        [Route("BySupplierId/{id:long}")]
        public async Task<IHttpActionResult> GetProductBySupplierId(long id)
        {
            List<Product> products = await _productService.GetBySupplierIdAsync(id);
            if (products.Count == 0)
            {
                return NotFound();
            }

            List<ProductDto> productDtos = new List<ProductDto>();

            Mapper.Map(products, productDtos);

            return Ok(productDtos);
        }

        [Route("ById/{id:int}")]
        public async Task<IHttpActionResult> GetProduct(long id)
        {
            Product product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductDto productDto = new ProductDto();

            Mapper.Map(product, productDto);

            return Ok(productDto);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutProduct(long id, ProductEditDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDto.Id)
            {
                return BadRequest();
            }

            try
            {
                productDto.Id = id;

                Product product = await _productService.GetByIdAsync(id);

                Mapper.Map(productDto, product);

                await _productService.UpdateAsync(product);

                return Ok(productDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostProduct(ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = new Product();

            Mapper.Map(productDto, product);

            product = await _productService.AddAsync(product);

            return CreatedAtRoute("ApiRoute", new { id = product.Id }, productDto);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(long id)
        {
            Product product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.IsDeleted = true;

            await _productService.UpdateAsync(product);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _productService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(long id)
        {
            return _productService.GetByIdAsync(id) != null;
        }
    }
}