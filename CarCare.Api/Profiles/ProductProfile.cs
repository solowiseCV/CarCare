using AutoMapper;
using CarCare.API.DTOS.Product.RequestDto;
using CarCare.API.DTOS.Product.ResponseDto;
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
