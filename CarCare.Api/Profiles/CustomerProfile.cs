using AutoMapper;
using CarCare.DTOs.Customer.RequestDto;
using CarCare.DTOs.Customer.ResponseDto;
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
