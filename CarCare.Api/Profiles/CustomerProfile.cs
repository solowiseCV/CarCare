using AutoMapper;
using CarCare.API.DTOS.Customer.RequestDto;
using CarCare.API.DTOS.Customer.ResponseDto;
using CarCare.Domain.Entities;

namespace CarCare.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerRequestDto, Customer>();
            CreateMap<Customer, CustomerResponseDto>();
        }
    }
}
