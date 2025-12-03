using AutoMapper;
using CarCare.DTOs.Product.RequestDto;
using CarCare.DTOs.Product.ResponseDto;
using CarCare.Domain.Entities;

namespace CarCare.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
