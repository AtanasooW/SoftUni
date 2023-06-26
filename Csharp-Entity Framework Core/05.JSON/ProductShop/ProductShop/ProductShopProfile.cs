using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            CreateMap<ImportUserDTO, User>();
            CreateMap<ImportCategoryDTO, Category>();
            CreateMap<ImportProductDTO, Product>();
            CreateMap<ImportCategoryProductDTO, CategoryProduct>();
            CreateMap<Product, ExportProductDTO>()
                .ForMember(d=> d.Seller, opt => opt.MapFrom(s=> $"{s.Seller.FirstName} {s.Seller.LastName}"));
        }
    }
}
