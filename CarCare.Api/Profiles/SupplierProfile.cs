using AutoMapper;
using CarCare.API.DTOS.Supplier.RequestDto;
using CarCare.API.DTOS.Supplier.ResponseDto;
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
