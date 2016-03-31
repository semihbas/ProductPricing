using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ProductPricing.Core.Entities;
using ProductPricing.Core.Services;
using ProductPricing.Data.Repositories;
using ProductPricing.Dto.Dtos;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace ProductPricing.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Suppliers")]
    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetSuppliers()
        {
            List<Supplier> suppliers = await _supplierService.GetAllAsync();

            List<SupplierDto> supplierDtos = new List<SupplierDto>();

            Mapper.Map(suppliers, supplierDtos);

            return Ok(supplierDtos);
        }

        [Route("ById/{id:int}")]
        public async Task<IHttpActionResult> GetSupplier(long id)
        {
            Supplier supplier = await _supplierService.GetByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            SupplierDto supplierDto = new SupplierDto();

            Mapper.Map(supplier, supplierDto);

            return Ok(supplierDto);
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutSupplier(long id, SupplierEditDto supplierDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplierDto.Id)
            {
                return BadRequest();
            }

            try
            {
                supplierDto.Id = id;

                Supplier supplier = await _supplierService.GetByIdAsync(id);

                Mapper.Map(supplierDto, supplier);

                await _supplierService.UpdateAsync(supplier);

                return Ok(supplierDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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
        [AllowAnonymous]
        public async Task<IHttpActionResult> PostSupplier(SupplierCreateDto supplierDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Supplier supplier = new Supplier();

            Mapper.Map(supplierDto, supplier);

            supplier = await _supplierService.AddAsync(supplier);

            return CreatedAtRoute("ApiRoute", new { id = supplier.Id }, supplierDto);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteSupplier(long id)
        {
            Supplier supplier = await _supplierService.GetByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            supplier.IsDeleted = true;

            await _supplierService.UpdateAsync(supplier);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _supplierService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplierExists(long id)
        {
            return _supplierService.GetByIdAsync(id) != null;
        }
    }
}