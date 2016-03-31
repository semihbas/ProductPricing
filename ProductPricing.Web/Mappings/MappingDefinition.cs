using AutoMapper;
using ProductPricing.Core.Entities;
using ProductPricing.Dto.Dtos;
using ProductPricing.Web.References;
using System;
using System.Globalization;
using System.Linq;

namespace ProductPricing.Web.Mapping
{
    public class MappingDefinitions
    {
        public void Initialise()
        {
            // _autoRegistrations();
            Register();
        }

        private void Register()
        {
            Mapper.CreateMap<AppliationUserDto, ApplicationUser>();
            Mapper.CreateMap<ApplicationUser, AppliationUserDto>();
            Mapper.CreateMap<Supplier, SupplierEditDto>();
            Mapper.CreateMap<Supplier, SupplierCreateDto>();
            Mapper.CreateMap<Supplier, SupplierDto>();
            Mapper.CreateMap<SupplierCreateDto, Supplier>();
            Mapper.CreateMap<SupplierEditDto, Supplier>();
            Mapper.CreateMap<SupplierDto, Supplier>();
            Mapper.CreateMap<Product, ProductCreateDto>();
            Mapper.CreateMap<Product, ProductEditDto>();
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductCreateDto, Product>();
            Mapper.CreateMap<ProductEditDto, Product>();
            Mapper.CreateMap<ProductDto, Product>();
        }

        private void _autoRegistrations()
        {
            var dataEntities =
                ReferencedAssemblies.Domain.
                    GetTypes().Where(x => typeof(IEntity).IsAssignableFrom(x)).ToList();

            var dtos =
                ReferencedAssemblies.Dto.
                GetTypes().Where(x => x.Name.EndsWith("Dto", true, CultureInfo.InvariantCulture)).ToList();

            foreach (var entity in dataEntities)
            {
                if (Mapper.GetAllTypeMaps().FirstOrDefault(m => m.DestinationType == entity || m.SourceType == entity) == null)
                {
                    var matchingDto =
                        dtos.FirstOrDefault(x => x.Name.Replace("Dto", string.Empty).Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));

                    if (matchingDto != null)
                    {
                        Mapper.CreateMap(entity, matchingDto);
                        Mapper.CreateMap(matchingDto, entity);
                    }
                }
            }
        }
    }
}