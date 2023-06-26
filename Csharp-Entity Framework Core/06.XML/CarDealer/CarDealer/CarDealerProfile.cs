using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDTO, Supplier>();
            CreateMap<ImportPartDTO, Part>();
            this.CreateMap<ImportCarDTO, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
            //CreateMap<ImportCategoryProductDTO, CategoryProduct>();
        }
    }
}
