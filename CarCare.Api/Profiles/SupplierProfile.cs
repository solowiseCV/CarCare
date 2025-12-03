using AutoMapper;
using CarCare.DTOs.Supplier.RequestDto;
using CarCare.DTOs.Supplier.ResponseDto;
using CarCare.Domain.Entities;

namespace CarCare.API.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierRequestDto, Supplier>();
            CreateMap<Supplier, SupplierResponseDto>();
        }
    }
}
