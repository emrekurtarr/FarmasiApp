using AutoMapper;
using Farmasi.Services.Catalog.BL.Dtos.Category;
using Farmasi.Services.Catalog.BL.Dtos.Product;
using Farmasi.Services.Catalog.BL.Dtos.Specification;
using Farmasi.Services.Catalog.DAL.Entities;

namespace Farmasi.Services.Catalog.BL.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //Category Mapping
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();

            //Product Mapping
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();

            //Specification Mapping
            CreateMap<Specification, SpecificationDto>().ReverseMap();
        }
    }
}
